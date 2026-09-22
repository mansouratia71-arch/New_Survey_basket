using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace Survey_Basket.Exceptionhandel
{
    public class GlobalException(ILogger<GotoExpression> logger) : IExceptionHandler
    {
        private readonly ILogger _logger= logger;
       
       
        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
           
                _logger.LogError(exception, "owerng masg{massge}", exception.Message);

                var statacode = StatusCodes.Status500InternalServerError;
            var promlem = new ProblemDetails
            {
                Status = 500,
                Title = "intrnale server error",
                Type = ""
            };

            httpContext.Response.StatusCode = statacode;    
            await httpContext.Response.WriteAsJsonAsync(promlem);
            return true;
 


            }
        }
    }

