using ArchivesExplorer.DataContext.Extensions;
using ArchivesExplorer.DataContext.Repositories.Interfaces.ReadRepositores;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ArchivesExplorer.DataContext.Repositories.ReadRepositories
{
    public abstract class BaseReadRepository<TEntity, TModel> :IBaseReadRepository<TEntity, TModel> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;
        protected BaseReadRepository(
            DbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<bool> CheckIfExistAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _dbSet.AnyAsync(predicate);
        }

        public async Task<IEnumerable<TModel>> GetAsync(params Expression<Func<TEntity, object>>[] includes)
        {
            var result = await _dbSet
                .IncludeMultiple(includes)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<TModel>>(result);
        }

        public async Task<IEnumerable<TModel>> GetAsync(int page, int pageSize, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = await _dbSet
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .IncludeMultiple(includes)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<TModel>>(result);
        }

        public async Task<IEnumerable<TModel>> GetAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = await _dbSet
                .Where(expression)
                .IncludeMultiple(includes)
                .AsNoTracking()
                .ToListAsync();

            return _mapper.Map<IEnumerable<TModel>>(result);
        }

        public async Task<TModel> GetUniqueAsync(Expression<Func<TEntity, bool>> expression, params Expression<Func<TEntity, object>>[] includes)
        {
            var result = await _dbSet
                .IncludeMultiple(includes)
                .AsNoTracking()
                .FirstOrDefaultAsync(expression);

            return _mapper.Map<TModel>(result);
        }
    }
}
