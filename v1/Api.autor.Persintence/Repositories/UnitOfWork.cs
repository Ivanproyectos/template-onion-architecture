using Api.autor.Domain.Interfaces.Repositories;
using Api.autor.Persintence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Api.autor.Persintence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly AuthorDbContext _authorDbContext;
        public UnitOfWork(AuthorDbContext authorDbContext)
        {
            _authorDbContext = authorDbContext;
        }

        public void Dispose()
        {
            _authorDbContext.Dispose();
        }
        public async Task SaveChangesAsync()
        {
            await _authorDbContext.SaveChangesAsync();
        }
    }
}
