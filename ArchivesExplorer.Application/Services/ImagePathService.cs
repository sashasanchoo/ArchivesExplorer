using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivesExplorer.DataContext.UoW;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Models;

namespace ArchivesExplorer.Application.Services
{
    public class ImagePathService : IImagePathService
    {
        private readonly IImagePathReadRepository _imagePathReadRepository;
        private readonly IArchivexExplorerUnitOfWork _unitOfWork;

        public ImagePathService(IImagePathReadRepository imagePathReadRepository, IArchivexExplorerUnitOfWork unitOfWork)
        {
            _imagePathReadRepository = imagePathReadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task AddImagePath(string path, Guid productId)
        {
            var doesPathExist = await _imagePathReadRepository.CheckIfExistAsync(x => x.Path == path && x.ProductId == productId);
            if (!doesPathExist)
            {
                var imagePath = new ImagePathModel
                {
                    Id = Guid.NewGuid(),
                    Path = path,
                    ProductId = productId
                };

                await _unitOfWork.Images.AddEntityAsync(imagePath);
                await _unitOfWork.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<ImagePathModel>> GetImagePaths(Guid productId)
        {
            var imagePaths = await _imagePathReadRepository.GetAsync(x => x.ProductId == productId);

            return imagePaths;
        }

        public async Task DeleteImagePaths(Guid productId)
        {
            var imagePaths = await _imagePathReadRepository.GetAsync(x => x.ProductId == productId);

            foreach (var item in imagePaths)
            {
                await _unitOfWork.Images.DeleteEntityByIdAsync(item.Id);
            }

            await _unitOfWork.SaveChangesAsync();
        }
    }
}
