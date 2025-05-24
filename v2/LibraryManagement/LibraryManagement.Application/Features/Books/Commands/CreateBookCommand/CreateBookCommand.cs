
using LibraryManagement.Application.Dtos.Books;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands.CreateBookCommand
{
    public class CreateBookCommand : IRequest<BookResponseDto>
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public int AuthorId { get; set; }
    }
}
