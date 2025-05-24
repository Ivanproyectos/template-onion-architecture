using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Commands.DeleteAuthorCommand
{
    internal class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteAuthorCommandHandler(
            IAuthorRepository authorRepository,
            IUnitOfWork unitOfWork
        )
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
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
