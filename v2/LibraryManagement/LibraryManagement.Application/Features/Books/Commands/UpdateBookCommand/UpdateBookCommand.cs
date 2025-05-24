using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands.UpdateBookCommand
{
    public class UpdateBookCommand : IRequest<Unit>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public int AuthorId { get; set; }
    }
}
