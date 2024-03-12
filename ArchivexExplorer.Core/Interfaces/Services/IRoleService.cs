using ArchivexExplorer.Domain.Models;

namespace ArchivexExplorer.Core.Interfaces.Services
{
    public interface IRoleService
    {
        Task<IEnumerable<RoleModel>> GetAllRoles();
        Task DeleteRole(Guid id);
        Task CreateRole(RoleModel model);
    }
}
