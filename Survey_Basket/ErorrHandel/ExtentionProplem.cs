using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace Survey_Basket.ErorrHandel
{
    public static class ExtentionProplem
    {
        public static ObjectResult ToProblem(this Result result, int codes)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException("error");
            }
            var proplem = Results.Problem(statusCode: codes);
            var problemdetalis = proplem.GetType().GetProperty("ProblemDetails")!.GetValue(proplem, null) as ProblemDetails;

            problemdetalis!.Extensions = new Dictionary<string, object?> {

                {"erorr",new[] {result.erorr} }
            };

            return new ObjectResult(problemdetalis);
        }
    }
}
