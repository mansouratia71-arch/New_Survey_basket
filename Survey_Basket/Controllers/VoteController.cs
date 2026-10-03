using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Survey_Basket.Dto.Vote;
using Survey_Basket.ExtentionMethod;
using Survey_Basket.Services.QuestionServece;

namespace Survey_Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VoteController(IVotes vote) : ControllerBase
    { 
        private readonly IVotes _vote=vote;
        [HttpGet]

        public async Task<IActionResult> Getquestion(int pollId, CancellationToken cancellation)
        {

            var result = await _vote.GetPollQuestion(pollId, User.GetUser()!, cancellation);
            return result.IsSuccess ? Ok(result.Value) : result.ToProblem();

        }
     
        [HttpPost]
        public async Task<IActionResult> AddVote(int pollId,VoteRequst requst ,CancellationToken cancellation)
        {

            var result = await _vote.AddVote(pollId, User.GetUser()!,requst,cancellation);
            return result.IsSuccess ? Ok() : result.ToProblem();

        }
    }
}
