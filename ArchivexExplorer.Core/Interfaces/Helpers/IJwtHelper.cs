using ArchivexExplorer.Domain.Enums;
using ArchivexExplorer.Domain.Models;
using System.Security.Claims;

namespace ArchivexExplorer.Core.Interfaces.Helpers
{
    public interface IJwtHelper
    {
        string? GenerateToken(ClaimsIdentity claimsIdentity, TokenAccessTypes accessType);
        ClaimsIdentity GenerateClaimsIdentity(UserModel user, TokenAccessTypes tokenType);
    }
}
