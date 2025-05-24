using LibraryManagement.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Interfaces.Repositories
{
    public interface IBookRepository
    {
        public Task<List<Book>> GetAllAsync();

        public Task<Book> GetAsync(int id);

        public Task<bool> ExistsAsync(int id);
        public void DeleteAsync(Book author);

        public Task<Book> AddAsync(Book author);
        public Task<Book> UpdateAsync(Book author);
    }
}
