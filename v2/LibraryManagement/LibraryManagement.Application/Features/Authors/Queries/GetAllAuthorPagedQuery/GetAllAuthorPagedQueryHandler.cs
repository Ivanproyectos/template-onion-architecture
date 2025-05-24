using LibraryManagement.Application.Dtos.Common;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Queries.GetAllAuthorPagedQuery
{
    internal class GetAllAuthorPagedQueryHandler
        : IRequestHandler<GetAllAuthorPagedQuery, PagedResultDto<Author>>
    {
        private readonly IAuthorRepository _authorRepository;

        public GetAllAuthorPagedQueryHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<PagedResultDto<Author>> Handle(
            GetAllAuthorPagedQuery request,
            CancellationToken cancellationToken
        )
        {
            var result = await _authorRepository.GetAllPagedAsync(request.Page, request.PageSize);

            return new PagedResultDto<Author>(
                result.Items,
                result.TotalCount,
                result.PageNumber,
                result.PageSize
            );
        }
    }
}
