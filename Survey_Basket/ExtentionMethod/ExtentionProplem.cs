using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using Survey_Basket.ErorrHandel;

namespace Survey_Basket.ExtentionMethod
{
    public static class ExtentionProplem
    {
        public static ObjectResult ToProblem(this Result result)
        {
            if (result.IsSuccess)
            {
                throw new InvalidOperationException("error");
            }
            var proplem = Results.Problem(statusCode:result.erorr.statuscode);
            var problemdetalis = proplem.GetType().GetProperty("ProblemDetails")!.GetValue(proplem, null) as ProblemDetails;

            problemdetalis!.Extensions = new Dictionary<string, object?> {

                {"erorr",new[] {result.erorr.code,result.erorr.Discraption} }
            };

            return new ObjectResult(problemdetalis);
        }
    }
}
