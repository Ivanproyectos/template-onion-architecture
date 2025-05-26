using LibraryManagement.Application.Dtos.Author;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Queries.GetAuthorByIdQuery
{
    public class GetAuthorByIdQuery : IRequest<AuthorResponseDto>
    {
        public int Id { get; set; }
    }
}
