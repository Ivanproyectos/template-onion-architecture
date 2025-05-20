using LibraryManagement.Application.Dtos.Author;
using LibraryManagement.Application.Dtos.Book;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Features.Author.Commands.CreateAuthorCommand
{
    public class CreateAuthorCommand : IRequest<AuthorResponse>
    {
        public string Name { get; set; }
        public string Nationality { get; set; }
        public List<BookDto> Books { get; set; }
        public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorResponse>
        {
            public Task<AuthorResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }


    }
}
