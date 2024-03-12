using ArchivesExplorer.DataContext.Entities;
using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivexExplorer.Domain.Models;
using AutoMapper;

namespace ArchivesExplorer.DataContext.Repositories.ReadRepositories
{
    public class OrderReadRepository : BaseReadRepository<Order, OrderModel>, IOrderReadRepository
    {
        public OrderReadRepository(ArchivesExplorerDbContext dbContext, IMapper mapper) : base(dbContext, mapper) {}
    }
}
