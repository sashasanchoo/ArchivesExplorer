using ArchivesExplorer.DataContext.Entities;
using ArchivesExplorer.DataContext.Repositories.Interfaces.WriteRepositores;
using ArchivexExplorer.Domain.Models;
using AutoMapper;

namespace ArchivesExplorer.DataContext.Repositories.WriteRepositories
{
    public class CategoryWriteRepository : BaseWriteRepository<Category, CategoryModel>, ICategoryWriteRepository
    {
        public CategoryWriteRepository(ArchivesExplorerDbContext dbContext, IMapper mapper) : base(dbContext, mapper) {}
    }
}
