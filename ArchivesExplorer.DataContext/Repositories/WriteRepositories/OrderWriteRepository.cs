using ArchivesExplorer.DataContext.Entities;
using ArchivesExplorer.DataContext.Repositories.Interfaces.WriteRepositores;
using ArchivexExplorer.Domain.Models;
using AutoMapper;

namespace ArchivesExplorer.DataContext.Repositories.WriteRepositories
{
    public class OrderWriteRepository : BaseWriteRepository<Order, OrderModel>, IOrderWriteRepository
    {
        public OrderWriteRepository(ArchivesExplorerDbContext dbContext, IMapper mapper) : base(dbContext, mapper) {}
    }
}
