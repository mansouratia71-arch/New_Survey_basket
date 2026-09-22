using Survey_Basket.Dto.EntityAutho;

namespace Survey_Basket.Services.jwtServices
{
    public interface IJwtServices
    {
        Task<(string Token, int ExpiresIn)> GenerateTokenAsync(ApplicationUser user,CancellationToken cancellation);
        Task<String?> Validation(string Token);

    }
}
