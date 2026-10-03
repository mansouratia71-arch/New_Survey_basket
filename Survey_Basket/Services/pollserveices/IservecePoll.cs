using Azure;
using Survey_Basket.Dto.Entitypoll;
using Survey_Basket.ErorrHandel;

namespace Survey_Basket.Services.pollserveices
{
    public interface IservecePoll
    {
        Task<Result<IEnumerable<Poll>>> GetAllAsync(CancellationToken cancellation=default);

        Task<IEnumerable<ResponsePoll>> GetAvlibleAsync(CancellationToken cancellation = default);
        Task<Result<Poll>> GetAsync(int id,CancellationToken cancellation=default);

        Task<Result<Poll>> Addasync(Poll poll,CancellationToken cancellation=default);

        Task<Result<bool>> UpdateAsync(int id,Poll poll,CancellationToken cancellation=default);

        Task<Result<bool>> DeleteAsync(int id,CancellationToken cancellation=default);

        Task<Result<Poll>> TogelPublishesdAsync(int id,CancellationToken cancellation=default);

    }
}
