using AutoMapper;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Commands.UpdateAuthorCommand
{
    internal class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, Unit>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateAuthorCommandHandler(
            IAuthorRepository authorRepository,
            IMapper mapper,
            IUnitOfWork unitOfWork
        )
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            UpdateAuthorCommand request,
            CancellationToken cancellationToken
        )
        {
            var author = await _authorRepository.GetAsync(request.Id);

            if (author == null)
            {
                throw new Exception($"Author with id {request.Id} not found");
            }

            author.UpdateDetails(request.Name, request.Nationality);

            await _authorRepository.UpdateAsync(author);

            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
