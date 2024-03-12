using ArchivexExplorer.Domain.Responses;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ArchivesExplorer.Filters
{
    public class RequestValidationFilter : IActionFilter
    {
        public void OnActionExecuted(ActionExecutedContext context)
        {
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            if (!context.ModelState.IsValid)
            {
                context.HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;

                context.Result = new ObjectResult(
                    new ErrorBodyResponse<object>(context.ModelState)
                    {
                        Body = context.ModelState.Select(x => new ValidationErrorResponse()
                        {
                            Field = x.Key,
                            Details = x.Value?.Errors.Select(x => x.ErrorMessage).FirstOrDefault()!
                        }),
                        ErrorMessage = "Validation error"
                    });
            }
        }
    }
}
