using System.Linq.Expressions;

namespace ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores
{
    public interface IBaseReadRepository<TEntity, TModel>
    {
        Task<IEnumerable<TModel>> GetAsync(params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TModel>> GetAsync(int page,
                                           int pageSize,
                                           params Expression<Func<TEntity, object>>[] includes);
        Task<IEnumerable<TModel>> GetAsync(Expression<Func<TEntity, bool>> expression,
                                           params Expression<Func<TEntity, object>>[] includes);
        Task<TModel> GetUniqueAsync(Expression<Func<TEntity, bool>> expression,
                                    params Expression<Func<TEntity, object>>[] includes);
        Task<bool> CheckIfExistAsync(Expression<Func<TEntity, bool>> predicate);
    }
}
