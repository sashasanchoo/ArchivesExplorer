using ArchivesExplorer.DataContext.Repositories.Interfaces.WriteRepositores;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ArchivesExplorer.DataContext.Repositories.WriteRepositories
{
    public abstract class BaseWriteRepository<TEntity, TModel> : IBaseWriteRepository<TModel> where TEntity : class
    {
        protected readonly DbContext _dbContext;
        protected readonly DbSet<TEntity> _dbSet;
        protected readonly IMapper _mapper;

        protected BaseWriteRepository(
            DbContext dbContext,
            IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
            _dbSet = _dbContext.Set<TEntity>();
        }

        public async Task<TModel> AddEntityAsync(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            await _dbSet.AddAsync(entity);

            return model;
        }

        public TModel UpdateEntity(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _dbContext.Entry(entity).State = EntityState.Modified;

            return model;
        }

        public TModel DeleteEntity(TModel model)
        {
            var entity = _mapper.Map<TEntity>(model);
            _dbSet.Remove(entity);

            return model;
        }

        public async Task<bool> CheckIfExistAsync(Expression<Func<TModel, bool>> predicate)
        {
            var expression = _mapper.Map<Expression<Func<TEntity, bool>>>(predicate);

            return await _dbSet.AnyAsync(expression);
        }

        public async Task<TModel> DeleteEntityByIdAsync(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity == null)
                throw new NullReferenceException(nameof(id));

            _dbSet.Remove(entity);
            var model = _mapper.Map<TModel>(entity);

            return model;
        }
    }
}
