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
            return await dbContext.Authors.ToListAsync();
        }

        public async Task<Author?> GetAsync(int id)
        {
            return await dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await dbContext.Authors.AnyAsync(a => a.Id == id);
        }

        public async Task DeleteAsync(int id)
        {
            var author = await dbContext.Authors.FirstOrDefaultAsync(a => a.Id == id);
            if (author != null)
            {
                dbContext.Authors.Remove(author);
            }

            await dbContext.SaveChangesAsync();
        }

        public async Task<Author> AddAsync(Author author)
        {
            await dbContext.Authors.AddAsync(author);
            await dbContext.SaveChangesAsync();
            return author;
        }

        public Task<Author> UpdateAsync(Author author)
        {
            dbContext.Authors.Update(author);
            dbContext.SaveChangesAsync();
            return Task.FromResult(author);
        }
    }
}
