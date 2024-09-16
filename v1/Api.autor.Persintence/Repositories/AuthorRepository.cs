using Api.autor.Domain.Entities;
using Api.autor.Domain.Interfaces.Repositories;
using Api.autor.Persintence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Api.autor.Persintence.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        readonly AuthorDbContext _authorDbContext;
        public AuthorRepository(AuthorDbContext authorDbContext)
        {
            _authorDbContext = authorDbContext;
        }
        public async Task<List<Author>> GetAllAuthorsAync()
        {
            return await _authorDbContext.Authors
                .Include(x => x.Books)
                .ToListAsync();
        }

        public async Task<Author> GetAuthorByIdAsync(int idAuthor)
        {
            return await _authorDbContext.Authors.FirstOrDefaultAsync(x => x.Id == idAuthor);
        }
    }
}
