using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey_Basket.ExtentionMethod;
using Survey_Basket.Services.ResultVote;

namespace Survey_Basket.Controllers
{
    [Route("api/polls/[controller]")]
    [ApiController]
    [Authorize]
    public class ResultController(IResultvote votes,ILogger<ResultController> logger) : ControllerBase
    {
        private readonly IResultvote _vote = votes;
        private readonly ILogger<ResultController> _logger= logger;
        [HttpGet]
        public async Task<ActionResult> GetpollVots(int PollId, CancellationToken cancellationToken)
        {
            _logger.LogWarning("the opject return {result}", PollId);
            var result=  await _vote.GetPollResultVote(PollId, cancellationToken);
          var x =  result.Value.Selectvote.Select(a => new
            {
                a.userId,
                a.subtion,
              selectQuestion = a.selectQuestion.Select(b => new {
                    b.question,
                    b.answer
                }).ToList()
            });
            var y = System.Text.Json.JsonSerializer.Serialize(x);
            _logger.LogWarning("the opject return {pollname}   {voteamsower}", result.Value.title, y);
            return result.IsSuccess ? Ok(result) : result.ToProblem();
        }

    }
}
