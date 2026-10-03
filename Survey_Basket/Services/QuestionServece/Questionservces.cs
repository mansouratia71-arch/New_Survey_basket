using Survey_Basket.Dto.EnttyQuestion;
using Survey_Basket.ErorrHandel;
using Survey_Basket.ErorrHandel.Error;

namespace Survey_Basket.Services.QuestionServece
{
    public class Questionservces(ApplictionDbcontextcs context) : IQuestionservesce
    {
         private readonly ApplictionDbcontextcs _context=context;

        public async Task<Result<QuestionResponse>> Addasync(int pollId, CancellationToken cancellationToken, QuestionRequste requste)
        {
            bool ispollEsist = await _context.Polls.AnyAsync(x => x.Id == pollId);
            if (!ispollEsist)
                return Result.Failure<QuestionResponse>(PollError.Notfound);
            bool questionisexist= await _context.Questions
                .AnyAsync(x => x.content == requste.content &&x.pollId==pollId);
            if(questionisexist)
                return Result.Failure<QuestionResponse>(PollError.Notfound);

            var question = requste.Adapt<Question>();
            question.pollId = pollId;
            foreach (var x in requste.AnswerRequst)
            {
                question.answer.Add(new Answer { content=x});
            }

            await _context.Questions.AddAsync(question);

            await _context.SaveChangesAsync(cancellationToken);

            var responce=question.Adapt<QuestionResponse>();

            return Result.Success<QuestionResponse>(responce);
            
        }

        public async Task<Result<List<QuestionResponse>>> GetAllasync(CancellationToken cancellation)
        {
           var model= await _context.Questions.Include(q=>q.answer).ToListAsync(cancellation);
            if(model is null)
                return Result.Failure<List<QuestionResponse>>(PollError.Notfound);
             var qresponse= model.Adapt<List<QuestionResponse>>();

            return Result.Success<List<QuestionResponse>>(qresponse);
        }

       

        public async Task<Result<List<QuestionResponse>>> GetByIdasync(int pollId, CancellationToken cancellation)
        {
            var poll= await _context.Polls.FindAsync(pollId, cancellation);
            if(poll is null)
                return Result.Failure<List<QuestionResponse>>(PollError.Notfound);

             await _context.Entry(poll).Collection(x => x.questions).LoadAsync(cancellation);
            foreach (var question in poll.questions)
            {
                await _context.Entry(question).Collection(x => x.answer).LoadAsync(cancellation);
            }
            if(_context.Questions is null)
            return Result.Failure<List<QuestionResponse>>(PollError.Notfound);

            var qresponse = _context.Questions.Adapt<List<QuestionResponse>>();

            return Result.Success<List<QuestionResponse>>(qresponse);
        }

        public async Task<Result> Toggle(int pollId, int id, CancellationToken cancellationToken)
        {
            var question = await _context.Questions.SingleOrDefaultAsync(x => x.pollId == pollId && x.Id == id);
            if(question is null)
                return Result.Failure(PollError.Notfound);

            question.IsActive=!question.IsActive;
            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
            
        }

      

        public async Task<Result> updateasync(int pollId, int id, QuestionRequste requste, CancellationToken cancellationToken)
        {
            var isexistcontent = await _context.Questions
     .AnyAsync(x => x.pollId == pollId && x.Id != id && x.content == requste.content);
            if (isexistcontent)
                return Result.Failure(PollError.Notfound);

            var question = await _context.Questions.Include(x => x.answer)
                .SingleOrDefaultAsync(x => x.pollId == pollId && x.Id == id);
            if (question is null)
                return Result.Failure(PollError.Notfound);

            question.content = requste.content;

            var cureuntanser = question.answer.Select(x =>  x.content).ToList();

            var newanswer =requste.AnswerRequst.Except(cureuntanser).ToList();

            foreach (var answer in newanswer)
            {
                question.answer.Add(new Answer {content= answer });
            }

            foreach (var item in question.answer.ToList())
            {
                item.IsActive = requste.AnswerRequst.Contains(item.content);
            }

            await _context.SaveChangesAsync(cancellationToken);

            return Result.Success();
        }
    } 
}
