using AutoMapper;
using LibraryManagement.Application.Dtos.Author;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Events;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthorCommand
{
    internal class CreateAuthorCommandHandler
        : IRequestHandler<CreateAuthorCommand, AuthorResponseDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public CreateAuthorCommandHandler(
            IAuthorRepository authorRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper,
            IMediator mediator
        )
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<AuthorResponseDto> Handle(
            CreateAuthorCommand request,
            CancellationToken cancellationToken
        )
        {
            var author = Author.Create(request.Name, request.Nationality);

            foreach (var book in request.Books)
            {
                author.AddBook(book.Title, book.PublicationYear);
            }

            await _authorRepository.AddAsync(author);

            await _unitOfWork.SaveChangesAsync();
            await _mediator.Publish(new CreateAuthorDomainEvent(author.Id));

            return _mapper.Map<AuthorResponseDto>(author);
        }
    }
}
