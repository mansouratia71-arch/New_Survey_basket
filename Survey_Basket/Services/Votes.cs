using Survey_Basket.Dto.Vote;
using Survey_Basket.ErorrHandel;
using Survey_Basket.ErorrHandel.Error;

namespace Survey_Basket.Services
{
    public class Votes(ApplictionDbcontextcs context):IVotes
    {
        private readonly ApplictionDbcontextcs _context=context;

        public async Task<Result> AddVote(int pollId, string userId, VoteRequst requst, CancellationToken cancellation )
        {
            
     
            var isvote = await _context.Votes.AnyAsync(x => x.pollid == pollId && x.userId == userId, cancellation);
            if (isvote)
                return Result.Failure(VoteErorr.dublicted);

            var isactive = await _context.Polls.AnyAsync(x => x.Id == pollId && x.isPublished && x.startdate <= DateOnly.FromDateTime(DateTime.UtcNow) && x.enddate >= DateOnly.FromDateTime(DateTime.UtcNow), cancellation);
            if (!isactive)
                return Result.Failure(VoteErorr.notfound);

            var questionexistinpoll=await _context.Questions.Where(x=>x.pollId==pollId).Select(y=> new {Id=y.Id}).ToListAsync(cancellation);

            var isexistinpoll = requst.answer.Select(y => new {Id= y.questionId }).SequenceEqual(questionexistinpoll);

            if (!isexistinpoll)
                return Result.Failure(VoteErorr.notfound);

            var vote = new Vote
            {
                pollid = pollId,
                userId = userId,
                submititon = DateTime.UtcNow,
                voteAnswer = requst.answer.Select(x => new VoteAnswer
                {
                    QuestionId = x.questionId,
                    AnswerId = x.answerId
                }).ToList(),
               

            };

            await _context.AddAsync(vote);
            await _context.SaveChangesAsync(cancellation);
            return Result.Success();
        }

        public async Task<Result<List<QuestionResponse>>> GetPollQuestion(int pollId, string userId, CancellationToken cancellationToken)
        {
            var isvote = await _context.Votes.AnyAsync(x => x.pollid == pollId && x.userId == userId, cancellationToken);
            if (isvote)
                return Result.Failure<List<QuestionResponse>>(VoteErorr.dublicted);

            var isactive = await _context.Polls.AnyAsync(x => x.Id == pollId && x.isPublished && x.startdate <= DateOnly.FromDateTime(DateTime.UtcNow) && x.enddate >= DateOnly.FromDateTime(DateTime.UtcNow), cancellationToken);
            if (!isactive)
                return Result.Failure<List<QuestionResponse>>(VoteErorr.notfound);

            var qution = await _context.Questions.Where(x => x.pollId == pollId && x.IsActive).Include(x => x.answer).Select(x => new QuestionResponse
            (
                x.Id,
                x.content,

                 x.answer.Where(p => p.IsActive).Select(a => new AnswerResponce
                (
                   a.Id,
                    a.content
                ))

            )).AsNoTracking().ToListAsync(cancellationToken);

            return Result.Success<List<QuestionResponse>>(qution);
        }
    }
}
