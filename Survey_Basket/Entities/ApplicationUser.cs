using Microsoft.AspNetCore.Identity;

namespace Survey_Basket.Entities
{
    public class ApplicationUser :IdentityUser
    {
        public string Firstname { get; set; }=string.Empty;

        public string Lastname { get; set; } =string.Empty;


        public ICollection<RefreshToken> RefreshTokens { get; set; }
            = new List<RefreshToken>();
    }
}
