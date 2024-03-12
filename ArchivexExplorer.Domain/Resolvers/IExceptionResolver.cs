using Microsoft.AspNetCore.Mvc.Filters;

namespace ArchivexExplorer.Domain.Resolvers
{
    public interface IExceptionResolver<T> : IExceptionResolver where T : Exception
    {
    }

    public interface IExceptionResolver
    {
        void OnException(ExceptionContext context);
    }
}
