using System.Linq.Expressions;

namespace ArchivesExplorer.DataContext.Repositories.Interfaces.WriteRepositores
{
    public interface IBaseWriteRepository<TModel>
    {
        Task<TModel> AddEntityAsync(TModel model);
        TModel UpdateEntity(TModel model);
        TModel DeleteEntity(TModel model);
        Task<TModel> DeleteEntityByIdAsync(Guid id);
        Task<bool> CheckIfExistAsync(Expression<Func<TModel, bool>> predicate);
    }
}
