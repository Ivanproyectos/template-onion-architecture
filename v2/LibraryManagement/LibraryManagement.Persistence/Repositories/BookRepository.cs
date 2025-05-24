using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces.Repositories;
using LibraryManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Persistence.Repositories
{
    public class BookRepository(MysqlContext dbContext) : IBookRepository
    {
        public async Task<List<Book>> GetAllAsync()
        {
            return await dbContext.Books.ToListAsync();
        }

        public async Task<Book?> GetAsync(int id)
        {
            return await dbContext.Books.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await dbContext.Books.AnyAsync(a => a.Id == id);
        }

        public void DeleteAsync(Book Book)
        {
            dbContext.Books.Remove(Book);
        }

        public async Task<Book> AddAsync(Book Book)
        {
            await dbContext.Books.AddAsync(Book);
            return Book;
        }

        public Task<Book> UpdateAsync(Book Book)
        {
            dbContext.Books.Update(Book);
            return Task.FromResult(Book);
        }
    }
}
