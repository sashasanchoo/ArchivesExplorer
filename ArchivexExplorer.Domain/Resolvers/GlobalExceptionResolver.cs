using ArchivexExplorer.Domain.Responses;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;

namespace ArchivexExplorer.Domain.Resolvers
{
    public class GlobalExceptionResolver : IExceptionResolver
    {
        private readonly ILogger _logger;

        public GlobalExceptionResolver(
            ILogger<GlobalExceptionResolver> logger)
        {
            _logger = logger;
        }

        public void OnException(ExceptionContext context)
        {
            var id = Guid.NewGuid();
            var errorResponse = new ErrorResponse
            {
                ErrorMessage = context.Exception.ToString()
            };

            _logger.LogCritical(context.Exception, $"ErrorId : {id}");
            context.HttpContext.Response.StatusCode = StatusCodes.Status500InternalServerError;
            context.Result = new ObjectResult(errorResponse);
        }
    }
}
