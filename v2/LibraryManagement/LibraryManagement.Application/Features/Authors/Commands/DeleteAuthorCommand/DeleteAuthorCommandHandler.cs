using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Commands.DeleteAuthorCommand
{
    internal class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorCommandHandler(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
        }

        public async Task<Unit> Handle(
            DeleteAuthorCommand request,
            CancellationToken cancellationToken
        )
        {
            var author = await _authorRepository.GetAsync(request.Id);

            if (author == null)
            {
                throw new Exception($"Author with id {request.Id} not found");
            }

            await _authorRepository.DeleteAsync(author);
            await _unitOfWork.CommitAsync();

            return Unit.Value;
        }
    }
}
