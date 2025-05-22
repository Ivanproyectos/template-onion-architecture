using LibraryManagement.Application.Dtos.Author;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Queries.GetAllAuthorQuery
{
    public class GetAllAuthorQuery : IRequest<List<AuthorResponse>>
    {
      public string Name { get; set; }
    }
}
