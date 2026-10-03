using Microsoft.Identity.Client;

namespace Survey_Basket.Dto.EntityAutho
{
    public record RegesterResponse(
    string Id,
    string Email,
    string UserName,
    string Token,
    int ExpiresIn

    
   );
  }
