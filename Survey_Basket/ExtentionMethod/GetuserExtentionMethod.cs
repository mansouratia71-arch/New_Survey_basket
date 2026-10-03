using System.Runtime.CompilerServices;
using System.Security.Claims;

namespace Survey_Basket.ExtentionMethod
{
    public static class GetuserExtentionMethod
    {
        public static string? GetUser(this ClaimsPrincipal User)
        {
            return User.FindFirst("sub")?.Value;
        }
    }
}
