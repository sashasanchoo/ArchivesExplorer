using ArchivexExplorer.Domain.Resolvers;
using Microsoft.AspNetCore.Mvc.Filters;

namespace ArchivesExplorer.Filters
{
    public class ExceptionFilter : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var exceptionType = context.Exception.GetType();

            while (exceptionType != typeof(Exception))
            {
                var genericResolver = typeof(IExceptionResolver<>).MakeGenericType(exceptionType);
                var implementation = context.HttpContext.RequestServices.GetService(genericResolver);

                if (implementation != null)
                {
                    ((IExceptionResolver)implementation).OnException(context);
                    return;
                }

                exceptionType = exceptionType.BaseType;
            }

            var globalResolver = context.HttpContext.RequestServices.GetService<IExceptionResolver>();
            globalResolver.OnException(context);
        }
    }
}
