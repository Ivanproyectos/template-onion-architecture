using LibraryManagement.Common.Dtos;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces.Repositories;
using LibraryManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Persistence.Repositories
{
    public class AuthorRepository(MysqlContext dbContext) : IAuthorRepository
    {
        public async Task<List<Author>> GetAllAsync()
        {
            return await dbContext.Authors.Include(a => a.Books).ToListAsync();
        }

        public async Task<Author?> GetAsync(int id)
        {
            return await dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await dbContext.Authors.AnyAsync(a => a.Id == id);
        }

        public async Task DeleteAsync(Author author)
        {
            if (author != null)
            {
                dbContext.Authors.Remove(author);
            }
        }

        public async Task<Author> AddAsync(Author author)
        {
            await dbContext.Authors.AddAsync(author);
            return author;
        }

        public Task<Author> UpdateAsync(Author author)
        {
            dbContext.Authors.Update(author);
            return Task.FromResult(author);
        }

        public async Task<PaginatedList<Author>> GetAllPagedAsync(int page, int pageSize)
        {
            var skip = (page - 1) * pageSize;
            var total = await dbContext.Authors.CountAsync();
            var items = await dbContext
                .Authors.Include(a => a.Books)
                .Skip(skip)
                .Take(pageSize)
                .ToListAsync();
            return new PaginatedList<Author>(items, total, page, pageSize);
        }
    }
}
