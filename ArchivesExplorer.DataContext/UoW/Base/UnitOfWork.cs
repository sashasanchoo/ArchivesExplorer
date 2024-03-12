using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore;
using AutoMapper;
using ArchivexExplorer.Domain.Exceptions.System;

namespace ArchivesExplorer.DataContext.UoW.Base
{
    public class UnitOfWork : IUnitOfWork
    {
        protected readonly DbContext _dbContext;
        protected readonly IMapper _mapper;
        private IDbContextTransaction? _transaction;

        public UnitOfWork(DbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<int> SaveChangesAsync()
        {
            return await _dbContext.SaveChangesAsync();
        }

        public void BeginTransaction()
        {
            if (_transaction != null)
            {
                throw new TransactionAlreadyExistsException();
            }

            _transaction = _dbContext.Database.BeginTransaction();
        }

        public void Commit()
        {
            if (_transaction == null)
            {
                throw new TransactionNotFoundException();
            }

            _transaction.Commit();
            _transaction.Dispose();
            _transaction = null;
        }

        public void Rollback()
        {
            if (_transaction == null)
            {
                throw new TransactionNotFoundException();
            }

            _transaction.Rollback();
            _transaction.Dispose();
            _transaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _transaction = null;
        }
    }
}
