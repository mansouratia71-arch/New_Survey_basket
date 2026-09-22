using Microsoft.AspNetCore.Identity.Data;
using Survey_Basket.Dto.EntityAutho;
using Survey_Basket.Dto.EntityRegester;

namespace Survey_Basket.Services.AthountcationServisece
{
    public interface IAuthservices
    {
      Task<AuthResponse?> login(Login login,CancellationToken cancellation);

        // Task<AuthResponse?> RegisterAsync(RequsteRegister request,CancellationToken cancellation);

       Task <AuthResponse?> GetRefreshToken(RequstRfreshTokencs requst,CancellationToken cancellation);


    }
}
