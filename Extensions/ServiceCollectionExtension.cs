using ctrmmvp.Data;
using ctrmmvp.Data.Models;
using ctrmmvp.DTOs.Auth;
using ctrmmvp.Services;
using ctrmmvp.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

namespace ctrmmvp.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddBeans(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            return services;
        }

        public static IServiceCollection AddDb(this IServiceCollection services, string dbUrl)
        {
            services.AddDbContext<CtrmDbContext>(options =>
             {
                 options.UseNpgsql(dbUrl, b => b.MigrationsAssembly(typeof(CtrmDbContext).Assembly.FullName));
             }, ServiceLifetime.Transient);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseNpgsql(dbUrl, b => b.MigrationsAssembly(typeof(AppDbContext).Assembly.FullName));
                //.AddInterceptors(new SoftDeleteInterceptor()); ;//aws default
            });

            services.AddIdentityCore<AppUser>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            })
            .AddRoles<IdentityRole>()
            .AddDefaultTokenProviders()
            .AddEntityFrameworkStores<AppDbContext>();

            return services;
        }

        public static IServiceCollection AddAuth(this IServiceCollection services, ConfigurationManager config)

        {
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidAudience = config["JwtConfig:ValidAudience"],
                    ValidIssuer = config["JwtConfig:ValidIssuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JwtConfig:TokenKey"]))
                };
            });

            services.AddAuthorization();

            return services;
        }

        public static IServiceCollection AddAppSettingsBeans(this IServiceCollection services, ConfigurationManager config)

        {
            services.Configure<OauthConfig>(config.GetSection(nameof(OauthConfig)));
            services.Configure<JwtConfig>(config.GetSection(nameof(JwtConfig)));

            return services;
        }

        public static void AddCTRMSwagger(this IServiceCollection service)
        {
            service.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Phlo API", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Auth Header",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer"
                });
                c.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oath2",
                        Name = "Bearer",
                        In = ParameterLocation.Header
                    },
                    new List<string>()
                }
                });
            });
        }

        public static IServiceCollection AddCtrmAuthorization(this IServiceCollection services)
        {
            services.AddAuthentication()
            .AddJwtBearer(options =>
            {
                // The API resource scope issued in authorization server
                options.Audience = "api offline_access";

                // URL of my authorization server
                options.Authority = "http://acumatica.local/dev2/identity/connect/token";
            });

            services.AddAuthorization(options =>
            {
                options.DefaultPolicy = new AuthorizationPolicyBuilder(JwtBearerDefaults.AuthenticationScheme)
                    .RequireAuthenticatedUser()
                    .Build();
            });
            return services;
        }
    }
}