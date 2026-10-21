using Microsoft.AspNetCore.Mvc;


namespace Survey_Basket.midlewire
{
    public class Exeptionmidlewire 
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<Exeptionmidlewire> _logger;
        public Exeptionmidlewire(RequestDelegate next,ILogger<Exeptionmidlewire> logger)
        {
            _next = next;
            _logger= logger;
            
        }
        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
              await _next(httpContext);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex,"owerng masg{massge}",ex.Message);

                var statacode = StatusCodes.Status500InternalServerError;
                var promlem = Results.Problem();
                var x = promlem.GetType().GetProperty("ProblemDetails")!.GetValue(promlem, null) as ProblemDetails;

                //var proplemdatalis = new ProblemDetails
                //{
                //    Status = StatusCodes.Status500InternalServerError,
                //    Title="internalServerError"
                //};
                httpContext.Response.StatusCode = statacode;
                await httpContext.Response.WriteAsJsonAsync(x);


            }
        }
    }
}
