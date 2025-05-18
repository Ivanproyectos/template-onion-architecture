using LibraryManagement.Application.Dtos.Author;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Author.Queries.GetAllAuthorQuery
{
    internal class GetAllAuthorQuery: IRequest<List<AuthorResponse>>
    {

    }
}
