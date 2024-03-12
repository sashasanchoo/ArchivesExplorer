using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using ArchivexExplorer.Domain.Responses;

namespace ArchivesExplorer.Filters
{
    public class ResponseFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
            switch (context.Result)
            {
                case OkObjectResult response:
                    context.Result = response.Value == null 
                        ? new OkObjectResult(new SuccessResponse())
                        : new OkObjectResult(new SuccessBodyResponse<object>(response.Value));
                    break;

                case EmptyResult:
                case OkResult:
                    context.Result = new OkObjectResult(new SuccessResponse());
                    break;

                default:
                    break;
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
        }
    }
}
