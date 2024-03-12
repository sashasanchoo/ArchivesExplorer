using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivesExplorer.DataContext.UoW;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Models;

namespace ArchivesExplorer.Application.Services
{
    public class RoleService : IRoleService
    {
        private readonly IRoleReadRepository _roleReadRepository;
        private readonly IArchivexExplorerUnitOfWork _unitOfWork;
        public RoleService(IRoleReadRepository roleReadRepository, IArchivexExplorerUnitOfWork unitOfWork)
        {
            _roleReadRepository = roleReadRepository;
            _unitOfWork = unitOfWork;
        }
        public async Task CreateRole(RoleModel role)
        {
            var isRoleExists = await _roleReadRepository.CheckIfExistAsync(x => x.RoleName == role.RoleName);
            if (isRoleExists)
            {
                throw new Exception();
            }

            role.Id = Guid.NewGuid();

            await _unitOfWork.Roles.AddEntityAsync(role);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteRole(Guid id)
        {
            await _unitOfWork.Roles.DeleteEntityByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task<IEnumerable<RoleModel>> GetAllRoles()
        {
            var roles = await _roleReadRepository.GetAsync();

            return roles;
        }
    }
}
