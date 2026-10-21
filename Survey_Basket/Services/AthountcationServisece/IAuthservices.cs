using Microsoft.AspNetCore.Identity.Data;
using Survey_Basket.Dto.EntityAutho;
using Survey_Basket.Dto.EntityRegester;
using Survey_Basket.ErorrHandel;

namespace Survey_Basket.Services.AthountcationServisece
{
    public interface IAuthservices
    {
      Task<AuthResponse?> login(Login login,CancellationToken cancellation);

     Task<RegesterResponse?> RegisterAsync(RequsteRegister request,CancellationToken cancellation);

       Task <AuthResponse?> GetRefreshToken(RequstRfreshTokencs requst,CancellationToken cancellation);

       Task<Result> RevokRefreshToken(string requst, CancellationToken cancellation);



    }
}
