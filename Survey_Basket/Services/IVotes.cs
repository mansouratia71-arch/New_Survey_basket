using Survey_Basket.Dto.Vote;
using Survey_Basket.ErorrHandel;

namespace Survey_Basket.Services
{
    public interface IVotes
    {
        Task<Result<List<QuestionResponse>>> GetPollQuestion(int pollId, string userId, CancellationToken cancellationToken);

        Task<Result> AddVote(int pollId, string userId , VoteRequst requst,CancellationToken cancellation=default);
    }
}
