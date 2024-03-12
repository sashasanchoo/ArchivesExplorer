using ArchivesExplorer.DataContext.Entities;
using ArchivesExplorer.DataContext.Repositories.Interfaces.WriteRepositores;
using ArchivexExplorer.Domain.Models;
using AutoMapper;

namespace ArchivesExplorer.DataContext.Repositories.WriteRepositories
{
    public class ProductWriteRepository : BaseWriteRepository<Product, ProductModel>, IProductWriteRepository
    {
        public ProductWriteRepository(ArchivesExplorerDbContext dbContext, IMapper mapper) : base(dbContext, mapper) {}
    }
}
