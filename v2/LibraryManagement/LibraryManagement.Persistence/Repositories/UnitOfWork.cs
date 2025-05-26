using System.Data;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace LibraryManagement.Persistence.Repositories
{
    public class UnitOfWork(MysqlContext context) : IUnitOfWork
    {
        private IDbContextTransaction _transaction;

        public async Task BeginTransactionAsync()
        {
            _transaction = await context.Database.BeginTransactionAsync(
                IsolationLevel.ReadCommitted
            );
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await context.SaveChangesAsync(cancellationToken);
                if (_transaction != null)
                {
                    await _transaction.CommitAsync();
                }
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                _transaction?.Dispose();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                _transaction.Dispose();
                _transaction = null;
            }
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await context.SaveChangesAsync(cancellationToken);
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            context.Dispose();
        }
    }
}
