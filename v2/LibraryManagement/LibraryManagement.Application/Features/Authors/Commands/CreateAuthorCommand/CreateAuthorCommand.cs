using LibraryManagement.Application.Dtos.Author;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommand : IRequest<AuthorResponse>
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public List<BookDto> Books { get; set; }

        public record struct BookDto
        {
            public int PublicationYear { get; set; }
            public string Title { get; set; }

        }

    }
}
