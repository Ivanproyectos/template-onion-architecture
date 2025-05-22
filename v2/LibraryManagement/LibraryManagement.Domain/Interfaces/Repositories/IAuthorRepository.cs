using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        public Task<List<Author>> GetAllAsync();

        public Task<Author?> GetAsync(int id);

        public Task<bool> ExistsAsync(int id);
        public Task DeleteAsync(Author author);

        public Task<Author> AddAsync(Author author);
        public Task<Author> UpdateAsync(Author author);
    }
}
