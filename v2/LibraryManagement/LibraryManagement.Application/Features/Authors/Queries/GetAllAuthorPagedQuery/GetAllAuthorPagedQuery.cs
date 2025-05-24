using LibraryManagement.Application.Dtos.Common;
using LibraryManagement.Common.Dtos;
using LibraryManagement.Domain.Entities;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Queries.GetAllAuthorPagedQuery
{
    public class GetAllAuthorPagedQuery: IRequest<PagedResultDto<Author>>
    {
        public int Page { get; set; }
        public int PageSize { get; set; }
    }
}
