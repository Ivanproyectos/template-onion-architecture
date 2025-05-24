using LibraryManagement.Application.Dtos.Books;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Queries.GetAllBookQuery
{
    public class GetAllBookQuery: IRequest<List<BookResponseDto>>
    {
    }
}
