using Microsoft.EntityFrameworkCore;
using Survey_Basket.Dto.Entitypoll;
using Survey_Basket.ErorrHandel;
using Survey_Basket.ErorrHandel.Error;


namespace Survey_Basket.Services.pollserveices
{
    public class Servicepoll(ApplictionDbcontextcs context) : IservecePoll
    {
        private readonly ApplictionDbcontextcs _context = context;    
        public async Task<Result<Poll>> Addasync(Poll poll, CancellationToken cancellation = default)
        {
            var result= await _context.Polls.AnyAsync(x=>x.title == poll.title);
            if (result)
              return  Result.Failure<Poll>(PollError.dublicateDPoll);
            await _context.AddAsync(poll, cancellation);
            await _context.SaveChangesAsync(cancellation);

            return Result.Success<Poll>(poll);
    
        }

        public async Task<Result<bool>> DeleteAsync(int id, CancellationToken cancellation = default)
        {
            var model = await GetAsync(id, cancellation);
            if (model.IsSuccess)
            {
                _context.Polls.Remove(model.Value);
                await _context.SaveChangesAsync(cancellation);
                return Result.Success<bool>(true);
            }
            else 
                return Result.Failure<bool>(PollError.Notfound);
        }

        public async Task<Result<IEnumerable<Poll>>> GetAllAsync(CancellationToken cancellation = default)
        {
           IEnumerable<Poll> poll= await _context.Polls.AsNoTracking().ToListAsync(cancellation);
            return Result.Success<IEnumerable<Poll>>(poll);
        }

        public async Task<Result<Poll>> GetAsync(int id, CancellationToken cancellation = default)
        {
            var poll= await _context.Polls.FindAsync(id, cancellation);
            if(poll == null)
            {
                return Result.Failure<Poll>(new Erorr("notFound", "the opject not found",StatusCodes.Status404NotFound));
            }
            return Result.Success<Poll>(poll);
        }

        public async Task<IEnumerable<ResponsePoll>> GetAvlibleAsync(CancellationToken cancellation = default)
        {
            return await _context.Polls.Where(x => x.isPublished && x.startdate <= DateOnly.FromDateTime(DateTime.UtcNow) && x.enddate >= DateOnly.FromDateTime(DateTime.UtcNow))
                .AsNoTracking().ProjectToType<ResponsePoll>().ToListAsync(cancellation);
        }

        public async Task<Result<Poll>> TogelPublishesdAsync(int id, CancellationToken cancellation = default)
        {
            var model = await GetAsync(id, cancellation);
            if (model.IsSuccess)
            {
                model.Value.isPublished = !model.Value.isPublished;

                await _context.SaveChangesAsync(cancellation);
                return Result.Success<Poll>(model.Value);
            }
            return Result.Failure<Poll>(PollError.Notfound);
        }

        public async Task<Result<bool>> UpdateAsync(int id, Poll poll,CancellationToken cancellation = default)
        {
            var model = await GetAsync(id, cancellation);
            if (model.IsSuccess)
            {
               var entity =model.Value;
               entity.enddate = poll.enddate;
               entity.startdate = poll.startdate;
               entity.title = poll.title;
               entity.isPublished= poll.isPublished;
               entity.sumary = poll.sumary;

               if (await _context.Polls.AnyAsync(x => x.title == entity.title && x.Id != entity.Id))
                    return Result.Failure<bool>(PollError.dublicateDPoll);
                await _context.SaveChangesAsync(cancellation);

                return Result.Success<bool>(true);
            }
            return Result.Failure<bool>(PollError.Notfound);


        }
    }
}
