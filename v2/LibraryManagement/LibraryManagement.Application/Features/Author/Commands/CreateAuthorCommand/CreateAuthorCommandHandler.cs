using LibraryManagement.Application.Dtos.Author;
using MediatR;

namespace LibraryManagement.Application.Features.Author.Commands.CreateAuthorCommand
{
    internal class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorResponse>
    {
        public Task<AuthorResponse> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
