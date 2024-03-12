using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivesExplorer.DataContext.UoW;
using ArchivexExplorer.Core.Interfaces.Helpers;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;

namespace ArchivesExplorer.Application.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductReadRepository _productReadRepository;
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IArchivexExplorerUnitOfWork _unitOfWork;
        private readonly IFileManager _fileManager;
        private readonly IImagePathService _imagePathService;

        public ProductService(IProductReadRepository productReadRepository,
            ICategoryReadRepository categoryReadRepository,
            IArchivexExplorerUnitOfWork unitOfWork,
            IFileManager fileManager,
            IImagePathService imagePathService)
        {
            _productReadRepository = productReadRepository;
            _categoryReadRepository = categoryReadRepository;
            _unitOfWork = unitOfWork;
            _fileManager = fileManager;
            _imagePathService = imagePathService;
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts(string categoryName)
        {
            var products = string.IsNullOrEmpty(categoryName) ?
                await _productReadRepository.GetAsync(x => x.Images, x => x.Category) :
                await _productReadRepository.GetAsync(x => x.Category.Name == categoryName, x => x.Images, x => x.Category);

            return products;
        }

        public async Task<ProductModel> GetProductById(Guid id)
        {
            var product = await _productReadRepository.GetUniqueAsync(x => x.Id == id, x => x.Comments, x => x.Images, x => x.Category);
            if(product == null)
            {
                throw new Exception();
            }

            return product;
        }

        public async Task<IEnumerable<ProductModel>> GetProductByName(string name)
        {
            var products = await _productReadRepository.GetAsync(x => x.Name.Contains(name), x => x.Images);

            return products;
        }

        public async Task CreateProduct(ProductModel product, string categoryName, IFormFileCollection files)
        {
            var doesProductExist = await _productReadRepository.CheckIfExistAsync(x => x.Name == product.Name);
            if (doesProductExist)
            {
                throw new Exception();
            }

            var category = await _categoryReadRepository.GetUniqueAsync(x => x.Name == categoryName);
            if (category == null)
            {
                throw new Exception();
            }

            product.Id = Guid.NewGuid();
            product.Published = DateTime.UtcNow;
            product.CategoryId = category.Id;

            await _unitOfWork.Products.AddEntityAsync(product);
            await _unitOfWork.SaveChangesAsync();

            foreach (var file in files)
            {
                await _imagePathService.AddImagePath(file.FileName, product.Id);
            }

            await _fileManager.CopyFiles(files);
        }

        public async Task UpdateProduct(ProductModel product, string categoryName, IFormFileCollection files)
        {
            var productToUpdate = await _productReadRepository.GetUniqueAsync(x => x.Id == product.Id);
            if (productToUpdate == null)
            {
                throw new Exception();
            }

            var category = await _categoryReadRepository.GetUniqueAsync(x => x.Name == categoryName);
            if (category == null)
            {
                throw new Exception();
            }

            product.CategoryId = category.Id;

            _unitOfWork.Products.UpdateEntity(product);
            await _unitOfWork.SaveChangesAsync();

            await _imagePathService.DeleteImagePaths(product.Id);

            foreach (var file in files)
            {
                await _imagePathService.AddImagePath(file.FileName, product.Id);
            }

            await _fileManager.CopyFiles(files);
        }

        public async Task DeleteProduct(Guid id)
        {
            await _unitOfWork.Products.DeleteEntityByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
