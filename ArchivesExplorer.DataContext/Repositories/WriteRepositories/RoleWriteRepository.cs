using ArchivesExplorer.DataContext.Entities;
using ArchivesExplorer.DataContext.Repositories.Interfaces.WriteRepositores;
using ArchivexExplorer.Domain.Models;
using AutoMapper;

namespace ArchivesExplorer.DataContext.Repositories.WriteRepositories
{
    public class RoleWriteRepository : BaseWriteRepository<Role, RoleModel>, IRoleWriteRepository
    {
        public RoleWriteRepository(ArchivesExplorerDbContext dbContext, IMapper mapper) : base(dbContext, mapper) {}
    }
}
