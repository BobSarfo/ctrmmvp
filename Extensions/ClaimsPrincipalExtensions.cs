using System;
using System.Security.Claims;

namespace ctrmmvp.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static string? GetUsername(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.GivenName);
        }

        public static string? GetUserId(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.Name);
        }

        public static string? GetUserAcumaticaToken(this ClaimsPrincipal claimsPrincipal)
        {
            return claimsPrincipal.FindFirstValue(ClaimTypes.Authentication);
        }
    }
}