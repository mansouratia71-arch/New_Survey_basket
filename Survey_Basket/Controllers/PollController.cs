using Mapster;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Survey_Basket.Dto.Entitypoll;
using Survey_Basket.ErorrHandel.Error;
using Survey_Basket.ExtentionMethod;
using Survey_Basket.Services.pollserveices;

namespace Survey_Basket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class PollController(IservecePoll servecePoll,ILogger<PollController> logger) : ControllerBase
    {
        private readonly IservecePoll _servecePoll = servecePoll;

        public ILogger<PollController> _Logger  = logger;

        [HttpPost]
        
        public async Task<IActionResult> Add(RequstPoll requstPoll, CancellationToken cancellation)
        {
            _Logger.LogInformation("this is poll{poll}", requstPoll.title);
           if(requstPoll != null)
           {
                var model = requstPoll.Adapt<Poll>();
                var result = await _servecePoll.Addasync(model,cancellation);
                if (result.IsSuccess)
                {
                    var responce = result.Value.Adapt<ResponsePoll>();
                    return Ok(responce);
                }

                return result.ToProblem();
               
           }
         
            return BadRequest();
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetbyId(int id, CancellationToken cancellation)
        {
           
            var model = await _servecePoll.GetAsync(id, cancellation);
            if (model.IsFailure)
                return model.ToProblem();

            ResponsePoll response = model.Value.Adapt<ResponsePoll>();
            return Ok(response);

        }
        [HttpGet]
        public async Task<IActionResult> GetAll(CancellationToken cancellation)
        {
            var models = await _servecePoll.GetAllAsync(cancellation);
            if (models.IsFailure)
            {
                return BadRequest(models.erorr);
            }
            var response = models.Value.Adapt<IEnumerable<ResponsePoll>>();
            return Ok(response);
        }
        [HttpPut]
        public async Task<IActionResult> Update(int id, RequstPoll model, CancellationToken cancellation)
        {
            if (model == null)
                return BadRequest("Invalid request data.");
            var poll = model.Adapt<Poll>();
            var Updated = await _servecePoll.UpdateAsync(id, poll, cancellation);
            if (Updated.IsSuccess)
                return NoContent();
            return Updated.ToProblem();
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id, CancellationToken cancellation)
        {
            var result = await _servecePoll.DeleteAsync(id, cancellation);
            if (result.IsSuccess)
                return NoContent();
            return result.ToProblem();
            
        }
        [HttpPatch("{id}/toggle-publish")]
        public async Task<IActionResult> TogglePublish(int id, CancellationToken cancellation)
        {

            var Updated = await _servecePoll.TogelPublishesdAsync(id, cancellation);
            if (Updated.IsSuccess) 
                  return Ok(Updated.Value);
            return Updated.ToProblem();
        }
        [HttpGet("curunt")]
        public async Task<IActionResult> Getcurant(CancellationToken cancellation)
        {
            var models = await _servecePoll.GetAvlibleAsync(cancellation);
            if (models is null)
            {
                return BadRequest();
            }
            
            return Ok(models);
        }
    }
}

