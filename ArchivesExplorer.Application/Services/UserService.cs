using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivesExplorer.DataContext.UoW;
using ArchivexExplorer.Core.Interfaces.Helpers;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Aggregates;
using ArchivexExplorer.Domain.Constants;
using ArchivexExplorer.Domain.Enums;
using ArchivexExplorer.Domain.Models;

namespace ArchivesExplorer.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IJwtHelper _jwtHelper;
        private readonly IRoleReadRepository _roleReadRepository;
        private readonly IUserReadRepository _userReadRepository;
        private readonly IArchivexExplorerUnitOfWork _unitOfWork;
        public UserService(IJwtHelper jwtHelper,
            IRoleReadRepository roleReadRepository,
            IUserReadRepository userReadRepository, 
            IArchivexExplorerUnitOfWork unitOfWork)
        {
            _jwtHelper = jwtHelper;
            _roleReadRepository = roleReadRepository;
            _userReadRepository = userReadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<string> GetUserName(Guid id)
        {
            var user = await _userReadRepository.GetUniqueAsync(x => x.Id == id);

            return user.Username;
        }

        public async Task<AuthResultAggregateModel> Register(UserModel model)
        {
            if (await CheckIfEmailExists(model.Email))
            {
                throw new Exception();
            }

            model.Id = Guid.NewGuid();
            model.Password = BCrypt.Net.BCrypt.HashPassword(model.Password);

            await AddToRoleAsync(model, UserConstants.DefaultUserRole);
            await _unitOfWork.Users.AddEntityAsync(model);
            await _unitOfWork.SaveChangesAsync();

            var createdUser = await _userReadRepository.GetUniqueAsync(x => x.Id == model.Id, x => x.Role);

            var result = new AuthResultAggregateModel
            {
                IsRegularUser = createdUser.Role.RoleName == UserConstants.DefaultUserRole,
                UserName = createdUser.Username,
                AccessToken = AddToken(createdUser, TokenAccessTypes.AccessToken),
                RefreshToken = AddToken(createdUser, TokenAccessTypes.RefreshToken)
            };

            return result;
        }

        public async Task<AuthResultAggregateModel> Login(string email, string password)
        {
            var user = await _userReadRepository.GetUniqueAsync(
                u => u.Email == email, 
                u => u.Role);

            if(user == null)
            {
                throw new Exception();//user not found
            }

            var isVerified = BCrypt.Net.BCrypt.Verify(password, user.Password);

            if (!isVerified)
            {
                throw new Exception();//wrong password
            }

            var result = new AuthResultAggregateModel
            {
                IsRegularUser = user.Role.RoleName == UserConstants.DefaultUserRole,
                UserName = user.Username,
                AccessToken = AddToken(user, TokenAccessTypes.AccessToken),
                RefreshToken = AddToken(user, TokenAccessTypes.RefreshToken)
            };

            return result;
        }

        public async Task ChangePassword(ChangePasswordAggregateModel changePasswordAggregateModel)
        {
            var user = await _userReadRepository.GetUniqueAsync(x => x.Id == changePasswordAggregateModel.Id);
            if (user == null)
            {
                throw new Exception();//user not found
            }

            var isVerified = BCrypt.Net.BCrypt.Verify(changePasswordAggregateModel.CurrentPassword, user.Password);
            if (!isVerified)
            {
                throw new Exception();//wrong password
            }

            user.Password = BCrypt.Net.BCrypt.HashPassword(changePasswordAggregateModel.NewPassword);
            var updatedUser = _unitOfWork.Users.UpdateEntity(user);

            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<TokenAggregateModel> RefreshTokens(Guid userId)
        {
            var user = await _userReadRepository.GetUniqueAsync(x => x.Id == userId);
            if(user == null)
            {
                throw new Exception();
            }

            var newTokens = new TokenAggregateModel()
            {
                AccessToken = AddToken(user, TokenAccessTypes.AccessToken),
                RefreshToken = AddToken(user, TokenAccessTypes.RefreshToken)
            };

            return newTokens;
        }

        private async Task<bool> CheckIfEmailExists(string email)
        {
            var result = await _userReadRepository.CheckIfExistAsync(x => x.Email == email);

            return result;
        }

        private string AddToken(UserModel user, TokenAccessTypes tokenType)
        {
            var tokenClaimsIdentity = _jwtHelper.GenerateClaimsIdentity(user, tokenType);

            var token = _jwtHelper.GenerateToken(tokenClaimsIdentity, tokenType);

            return token!;
        }

        private async Task AddToRoleAsync(UserModel user, string roleName)
        {
            var role = await _roleReadRepository.GetUniqueAsync(r => r.RoleName == roleName);

            if(role == null)
            {
                throw new Exception();
            }

            user.RoleId = role.Id;
        }
    }
}
