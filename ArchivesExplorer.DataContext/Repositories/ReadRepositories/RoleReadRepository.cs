using ArchivesExplorer.DataContext.Entities;
using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivexExplorer.Domain.Models;
using AutoMapper;

namespace ArchivesExplorer.DataContext.Repositories.ReadRepositories
{
    public class RoleReadRepository : BaseReadRepository<Role, RoleModel>, IRoleReadRepository
    {
        public RoleReadRepository(ArchivesExplorerDbContext dbContext, IMapper mapper) : base(dbContext, mapper) { }
    }
}
