using ctrmmvp.Data.Models;
using ctrmmvp.DTOs.Auth;
using ctrmmvp.Services.Interface;
using HotelReviewsAPI.Models.DTO;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace ctrmmvp.Services
{
    public class AuthService : IAuthService
    {
        private readonly ILogger<AuthService> _logger;
        private readonly UserManager<AppUser> _userManager;
        private readonly JwtConfig _jwtConfig;
        private readonly OauthConfig _oauthconfig;
        private readonly string _basicAuthHeader;

        public AuthService(ILogger<AuthService> logger, IOptions<OauthConfig> oauthconfig, UserManager<AppUser> userManager, IOptions<JwtConfig> jwtConfig)
        {
            _logger = logger;
            _userManager = userManager;
            _jwtConfig = jwtConfig.Value;
            _oauthconfig = oauthconfig.Value;
            _basicAuthHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes($"{_oauthconfig.ClientId}:{_oauthconfig.ClientSecret}"));
        }

        public async Task<LoginResponse> LoginAsync(LoginRequest loginRequest)
        {
            var user = await _userManager.FindByNameAsync(loginRequest.Name);

            if (user == null)
            {
                user = new AppUser { UserName = loginRequest.Name };
                await _userManager.CreateAsync(user);
            }

            var acumaticatoken = await GetAccessTokenAsync(loginRequest.Name, loginRequest.Password);

            user.AcuRefreshToken = acumaticatoken.refresh_token;
            user.DefaultBranchId = acumaticatoken.branch;
            user.Branches.Add(acumaticatoken.branch);

            await _userManager.UpdateAsync(user);

            var accessToken = await GenerateTokenAsync(user, acumaticatoken.access_token);

            return new LoginResponse { Name = user.UserName, Token = accessToken };
        }

        public async Task<AccessTokenResponse?> GetAccessTokenAsync(string username, string password)
        {
            // Prepare request data
            var requestData = new FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("grant_type", "password"),
                new KeyValuePair<string, string>("username", username),
                new KeyValuePair<string, string>("password", password),
                new KeyValuePair<string, string>("scope", _oauthconfig.Scope)
            });

            // Create HttpClient
            using var httpClient = new HttpClient();

            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", _basicAuthHeader);

            var response = await httpClient.PostAsync(_oauthconfig.TokenUrl, requestData);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStreamAsync();

                var accessTokenResponse = await JsonSerializer.DeserializeAsync<AccessTokenResponse>(responseContent);

                int branchId = GetBranchIdFromCookies(response.Headers.GetValues("Set-Cookie"));

                if (accessTokenResponse is not null)
                {
                    accessTokenResponse.branch = branchId;
                }

                return accessTokenResponse;
            }
            else
            {
                _logger.LogWarning("Invalid login for {username} at ", username);
            }

            return null;
        }

        public async Task<object> GetAccessTokenFromRefreshTokendAsync(string refreshToken, string username)
        {
            using HttpClient httpClient = new HttpClient();
            // Prepare request data
            var requestData = new FormUrlEncodedContent(new[]
            {
            new KeyValuePair<string, string>("grant_type", "refresh_token"),
            new KeyValuePair<string, string>("refresh_token", refreshToken)
        });

            // Add headers
            httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", _basicAuthHeader);

            // Make POST request to token endpoint
            var response = await httpClient.PostAsync(_oauthconfig.TokenUrl, requestData);

            if (response.IsSuccessStatusCode)
            {
                var responseContent = await response.Content.ReadAsStreamAsync();

                var accessTokenResponse = await JsonSerializer.DeserializeAsync<AccessTokenResponse>(responseContent);

                int branchId = GetBranchIdFromCookies(response.Headers.GetValues("Set-Cookie"));

                if (accessTokenResponse is not null)
                {
                    accessTokenResponse.branch = branchId;
                }

                return accessTokenResponse;
            }
            else
            {
                _logger.LogWarning("Access Token login failed for {username} at ", username);
            }

            return null;
        }

        private static int GetBranchIdFromCookies(IEnumerable<string> cookies)
        {
            int branchId = -1;
            foreach (var cookie in cookies)
            {
                if (cookie.Contains("UserBranch"))
                {
                    branchId = GetBranch(cookie);
                }
            }
            return branchId;
        }

        private static int GetBranch(string cookieString)
        {
            var branchStr = cookieString.Split(';')[0].Split("=")[1];
            int.TryParse(branchStr, out int value);

            return value;
        }

        public static string ValidateToken(string token, JwtConfig jwtConfig)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var authSigningkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtConfig.TokenKey));

            var validationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                ValidateIssuer = false,
                ValidateAudience = false,
                IssuerSigningKey = authSigningkey,
                ValidIssuer = jwtConfig.ValidIssuer,
                ValidAudience = jwtConfig.ValidAudience,
                ClockSkew = TimeSpan.Zero,
                ValidateLifetime = true
            };

            var valid = tokenHandler.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

            if (valid == null) return null;

            var jwtToken = (JwtSecurityToken)validatedToken;

            var userId = jwtToken.Claims.First(x => x.Type == ClaimTypes.Name).Value;

            return userId;
        }

        private async Task<string> GenerateTokenAsync(AppUser appUser, string acumaticaAccessToken)
        {
            var claims = new List<Claim> {
                new Claim(ClaimTypes.NameIdentifier,appUser.DefaultBranchId.ToString()),
                new Claim(ClaimTypes.Name, appUser.Id),
                new Claim(ClaimTypes.GivenName, appUser.UserName),
                new Claim(ClaimTypes.Authentication, acumaticaAccessToken)
            };

            var userRoles = await _userManager.GetRolesAsync(appUser);

            foreach (var userRole in userRoles)
            {
                claims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var authSigningkey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtConfig.TokenKey));
            var tokenOptions = new JwtSecurityToken(
                    issuer: _jwtConfig.ValidIssuer,
                    audience: _jwtConfig.ValidAudience,
                    expires: DateTime.Now.AddHours(_jwtConfig.TokenExpiry),
                    claims: claims,
                    signingCredentials: new SigningCredentials(authSigningkey, SecurityAlgorithms.HmacSha512)
                );

            return new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        }
    }
}