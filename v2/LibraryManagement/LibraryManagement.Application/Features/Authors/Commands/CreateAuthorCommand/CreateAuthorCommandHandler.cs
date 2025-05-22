using AutoMapper;
using LibraryManagement.Application.Dtos.Author;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Commands.CreateAuthorCommand
{
    internal class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, AuthorResponse>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateAuthorCommandHandler(
            IAuthorRepository authorRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _authorRepository = authorRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<AuthorResponse> Handle(
            CreateAuthorCommand request,
            CancellationToken cancellationToken
        )
        {
            var author = Author.Create(request.Name, request.Nationality);
            var books = request.Books.Select(x => Book.Create(x.Title, x.PublicationYear)).ToList();

            foreach (var book in books)
            {
                author.AddBook(book.Title, book.PublicationYear);
            }

            await _unitOfWork.BeginTransactionAsync();
            await _authorRepository.AddAsync(author);

            await _unitOfWork.CommitAsync();

            return _mapper.Map<AuthorResponse>(author);
        }
    }
}
