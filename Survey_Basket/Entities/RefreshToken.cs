using System.ComponentModel.DataAnnotations.Schema;

namespace Survey_Basket.Entities
{
    public class RefreshToken
    {
        public string Id { get; set; }=Guid.NewGuid().ToString();

        public string Token { get; set; }=string.Empty;

        public DateTime Createdon { get; set; }

        public DateTime Expireson { get; set; }

        public DateTime? RevokedOn { get; set; }

        public bool isExpired=>DateTime.UtcNow >=Expireson;

        public bool isActive => RevokedOn is null && !isExpired;

        public string UserId { get; set; } = string.Empty;

        public ApplicationUser User { get; set; } = null!;

    }
}
