

namespace Survey_Basket.Dto.EntityAutho
{
    public record AuthResponse(
    string Id,
    string Email,
    string UserName,
    string Token,
    int ExpiresIn,
    string RefreshToken,
    DateTime ExpiresInRefreshToken
   );
  }
