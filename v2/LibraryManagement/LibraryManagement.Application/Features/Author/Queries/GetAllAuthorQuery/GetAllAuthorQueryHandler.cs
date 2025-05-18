using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Application.Dtos.Author;
using MediatR;

namespace LibraryManagement.Application.Features.Author.Queries.GetAllAuthorQuery
{
    internal class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, List<AuthorResponse>>
    {
        public Task<List<AuthorResponse>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
