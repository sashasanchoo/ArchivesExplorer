using ArchivexExplorer.Domain.Models;

namespace ArchivexExplorer.Core.Interfaces.Services
{
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryModel>> GetAllCategories();
        Task<CategoryModel> GetCategoryById(Guid id);
        Task CreateCategory(CategoryModel category);
        Task UpdateCategory(Guid id, string name);
        Task DeleteCategory(Guid id);
    }
}
