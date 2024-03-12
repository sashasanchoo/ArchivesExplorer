using ArchivexExplorer.Domain.Aggregates;
using ArchivexExplorer.Domain.Models;

namespace ArchivexExplorer.Core.Interfaces.Services
{
    public interface IUserService
    {
        Task<AuthResultAggregateModel> Register(UserModel user);
        Task<AuthResultAggregateModel> Login(string email, string password);
        Task ChangePassword(ChangePasswordAggregateModel changePasswordAggregateModel);
        Task<TokenAggregateModel> RefreshTokens(Guid userId);
    }
}
