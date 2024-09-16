using Api.autor.Domain.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.autor.Domain.Interfaces.Repositories
{
    public interface IAuthorRepository
    {
        Task<List<Author>> GetAllAuthorsAync();
        Task<Author> GetAuthorByIdAsync(int idAuthor);
    }
}
