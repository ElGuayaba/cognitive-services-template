using System.Security.Claims;

namespace NetcoreTemplate.Api.WebApi.Extension
{
    public static class ClaimsPrincipalExtension
    {
        public static string GetId(this ClaimsPrincipal principal)
        {
            return principal.FindFirstValue(ClaimTypes.NameIdentifier);
        }
    }
}