using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Survey_Basket.Dto.EntityAutho;
using Survey_Basket.Dto.EntityRegester;
using Survey_Basket.Services.AthountcationServisece;

namespace Survey_Basket.Controllers
{
    [Route("[controller]")]
    [ApiController]
    
    public class AthuntcationController(IAuthservices authservices) : ControllerBase
    {
        private readonly IAuthservices _authservices=authservices;

        [HttpPost]

        public async Task<IActionResult> login(Login model,CancellationToken cancellation)
        {
            var user=await _authservices.login(model,cancellation);
            if(user!=null) 
                return Ok(user);

            return NoContent();
        }
        // [HttpPost("register")]
        //public async Task<IActionResult> Register(RequsteRegister model, CancellationToken cancellation)
        //{
        //    var user = await _authservices.RegisterAsync(model, cancellation);
        //    if (user != null)
        //        return Ok(user);

        //    return NoContent();
        //}
        [HttpPost("refreshtoken")]
        public async Task<IActionResult> GetRefreshToken(RequstRfreshTokencs requst,CancellationToken cancellation)
        {
            var response = await _authservices.GetRefreshToken(requst, cancellation);

            if(response!=null) 
                return Ok(response);
            else 
                return NotFound();    
        }
    }

}
