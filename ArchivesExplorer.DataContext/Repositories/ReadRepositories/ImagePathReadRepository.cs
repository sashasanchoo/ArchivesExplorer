using ArchivesExplorer.DataContext.Entities;
using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivexExplorer.Domain.Models;
using AutoMapper;

namespace ArchivesExplorer.DataContext.Repositories.ReadRepositories
{
    public class ImagePathReadRepository : BaseReadRepository<ImagePath, ImagePathModel>, IImagePathReadRepository
    {
        public ImagePathReadRepository(ArchivesExplorerDbContext dbContext, IMapper mapper) : base(dbContext, mapper) {}
    }
}
