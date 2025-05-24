using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Dtos.Books
{
    public record struct BookResponseDto(
       int Id,
       string Title,
       string PublicationYear)
    {
    }
}
