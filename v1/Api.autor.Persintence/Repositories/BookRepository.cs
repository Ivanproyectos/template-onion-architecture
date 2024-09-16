using Api.autor.Domain.Entities;
using Api.autor.Domain.Interfaces.Repositories;
using Api.autor.Persintence.Contexts;

namespace Api.autor.Persintence.Repositories
{

    public class BookRepository: IBookRepository
    {
        readonly AuthorDbContext _authorDbContext;
        public BookRepository(AuthorDbContext authorDbContext)
        {
            _authorDbContext = authorDbContext;
        }
        public async Task<Book> CreateBookAsync(Book book)
        {
            await _authorDbContext.AddAsync(book);
            return book;
        }

    }
}
