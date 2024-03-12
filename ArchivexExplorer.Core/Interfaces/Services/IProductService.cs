using ArchivexExplorer.Domain.Models;
using Microsoft.AspNetCore.Http;

namespace ArchivexExplorer.Core.Interfaces.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductModel>> GetAllProducts(string categoryName);
        Task<IEnumerable<ProductModel>> GetProductByName(string name);
        Task<ProductModel> GetProductById(Guid id);
        Task CreateProduct(ProductModel product, string categoryName, IFormFileCollection files);
        Task UpdateProduct(ProductModel product, string categoryName, IFormFileCollection files);
        Task DeleteProduct(Guid id);
    }
}
