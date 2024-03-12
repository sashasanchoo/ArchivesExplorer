using ArchivexExplorer.Domain.Models;

namespace ArchivexExplorer.Core.Interfaces.Services
{
    public interface IImagePathService
    {
        Task AddImagePath(string path, Guid productId);
        Task<IEnumerable<ImagePathModel>> GetImagePaths(Guid productId);
        Task DeleteImagePaths(Guid productId);
    }
}
