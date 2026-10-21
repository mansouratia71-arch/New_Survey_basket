using Survey_Basket.Dto.Result;
using Survey_Basket.ErorrHandel;
using Survey_Basket.ErorrHandel.Error;
using Survey_Basket.Services.ResultVote;

namespace Survey_Basket.Services.ResulVotet
{
    public class ResultVote(ApplictionDbcontextcs applictionDbcontextcs) : IResultvote
    {
        private readonly ApplictionDbcontextcs _context = applictionDbcontextcs;

        public async Task<Result<VotePollResponse>> GetPollResultVote(int PollId ,CancellationToken cancellationToken){

           var ispollexist=await _context.Polls.AnyAsync(x=>x.Id==PollId);

            if (!ispollexist)
                return Result.Failure<VotePollResponse>(PollError.Notfound);

            var response = await _context.Polls.Where(x => x.Id == PollId)
                .Select(x => new VotePollResponse
                (
                     x.title,
                     x.Votes.Select(v => new VoteResponse(

                         v.userId,
                         v.submititon,
                         v.voteAnswer.Select(a => new QuestionAnserREsponse
                        (
                            a.Question.content,
                            a.Answer.content
                        ))
                    ))
                )).SingleOrDefaultAsync(cancellationToken);

            return Result.Success<VotePollResponse>(response!);

             
                
                
                
           

             
                        

        }
    }
}
