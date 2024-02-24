using ctrmmvp.DTOs.Auth;
using ctrmmvp.Extensions;
using ctrmmvp.Services.Interface;
using Microsoft.AspNetCore.Mvc;

namespace ctrmmvp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginRequest loginRequest)
        {
            var result = await _authService.LoginAsync(loginRequest);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [HttpGet("profile")]
        public async Task<IActionResult> ProfileDetailsAsync()
        {
            var token = User.GetUserAcumaticaToken();
            var name = User.GetUsername();
            var res = await _authService.GetAcuUserDetails(name, token);

            return Ok(res);
        }

        [HttpPost("logout")]
        public async Task<IActionResult> LogoutAsync()
        {
            return Ok();
        }
    }
}