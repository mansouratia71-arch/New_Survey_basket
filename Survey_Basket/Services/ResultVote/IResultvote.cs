using Survey_Basket.Dto.Result;
using Survey_Basket.ErorrHandel;

namespace Survey_Basket.Services.ResultVote
{
    public interface IResultvote
    {
        public Task<Result<VotePollResponse>> GetPollResultVote(int PollId, CancellationToken cancellationToken);
    }
}
