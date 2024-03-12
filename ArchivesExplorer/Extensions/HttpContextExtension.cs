using ArchivexExplorer.Domain.Constants;
using ArchivexExplorer.Domain.Exceptions.System;

namespace ArchivesExplorer.Extensions
{
    public static class HttpContextExtension
    {
        public static Guid GetUserId(this HttpContext httpContext)
        {
            var clientIdClaim = httpContext.User.Claims
                .FirstOrDefault(n => n.Type == ClaimConstants.UserId);

            if (clientIdClaim is null)
                throw new ClaimNotFoundException(nameof(ClaimConstants.UserId));

            return Guid.Parse(clientIdClaim.Value);
        }
    }
}
