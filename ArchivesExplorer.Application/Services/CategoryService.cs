using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using ArchivesExplorer.DataContext.UoW;
using ArchivexExplorer.Core.Interfaces.Services;
using ArchivexExplorer.Domain.Models;

namespace ArchivesExplorer.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryReadRepository _categoryReadRepository;
        private readonly IArchivexExplorerUnitOfWork _unitOfWork;

        public CategoryService(ICategoryReadRepository categoryReadRepository, 
            IArchivexExplorerUnitOfWork unitOfWork)
        {
            _categoryReadRepository = categoryReadRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<CategoryModel>> GetAllCategories()
        {
            return await _categoryReadRepository.GetAsync();
        }

        public async Task<CategoryModel> GetCategoryById(Guid id)
        {
            var category = await _categoryReadRepository.GetUniqueAsync(x => x.Id == id);

            if (category == null)
            {
                throw new Exception();
            }

            return category;
        }

        public async Task CreateCategory(CategoryModel category)
        {
            var doesCategoryExist = await _categoryReadRepository.CheckIfExistAsync(x => x.Name == category.Name);
            if (doesCategoryExist)
            {
                throw new Exception();
            }

            category.Id = Guid.NewGuid();

            await _unitOfWork.Categories.AddEntityAsync(category);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task UpdateCategory(Guid id, string name)
        {
            var categoryToUpdate = await _categoryReadRepository.GetUniqueAsync(x => x.Id == id);
            if (categoryToUpdate == null)
            {
                throw new Exception();
            }

            categoryToUpdate.Name = name;
            _unitOfWork.Categories.UpdateEntity(categoryToUpdate);
            await _unitOfWork.SaveChangesAsync();
        }

        public async Task DeleteCategory(Guid id)
        {
            await _unitOfWork.Categories.DeleteEntityByIdAsync(id);
            await _unitOfWork.SaveChangesAsync();
        }
    }
}
