using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey_Basket.Dto.EnttyQuestion;
using Survey_Basket.ExtentionMethod;
using Survey_Basket.Services.QuestionServece;

namespace Survey_Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    
    public class QuestionController(IQuestionservesce questionservesce) : ControllerBase
    {
        private readonly IQuestionservesce _questionservesce = questionservesce;
        [HttpPost]
    public async Task<IActionResult> addAsync(int pollId, QuestionRequste requste, CancellationToken cancellation)
        {
            var reslt = await _questionservesce.Addasync(pollId, cancellation, requste);
            if (reslt.IsSuccess)
                return Ok(reslt.Value);

            return reslt.ToProblem();
        }
        [HttpGet]
        public async Task<IActionResult> GetAllAsync(CancellationToken cancellation)
        {
            var reslt = await _questionservesce.GetAllasync(cancellation);
            if (reslt.IsSuccess)
                return Ok(reslt.Value);

            return reslt.ToProblem();
        }
        [HttpGet("{pollId}")]
        public async Task<IActionResult> GetByPollIDAsync( [FromRoute]int pollId,CancellationToken cancellation)
        {
            var reslt = await _questionservesce.GetByIdasync(pollId,cancellation);
            if (reslt.IsSuccess)
                return Ok(reslt.Value);

            return reslt.ToProblem();
        }

        [HttpPut("togle/{id}")]
        public async Task<IActionResult> Toggle([FromQuery] int pollId,[FromRoute]int id, CancellationToken cancellation)
        {
            var reslt = await _questionservesce.Toggle(pollId,id,cancellation);
            if (reslt.IsSuccess)
                return Ok();

            return reslt.ToProblem();
        }

        [HttpPut]
        public async Task<IActionResult> updatAsync(int pollId, int id,QuestionRequste requste, CancellationToken cancellation)
        {
            var reslt = await _questionservesce.updateasync(pollId, id, requste, cancellation);
            if (reslt.IsSuccess)
                return Ok();

            return reslt.ToProblem();
        }
   


    }
}