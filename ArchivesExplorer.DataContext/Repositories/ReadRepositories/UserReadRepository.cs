using ArchivesExplorer.DataContext.Entities;
using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivexExplorer.Domain.Models;
using AutoMapper;

namespace ArchivesExplorer.DataContext.Repositories.ReadRepositories
{
    public class UserReadRepository : BaseReadRepository<User, UserModel>, IUserReadRepository
    {
        public UserReadRepository(ArchivesExplorerDbContext dbContext, IMapper mapper) : base (dbContext, mapper) {}
    }
}
