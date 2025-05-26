using AutoMapper;
using LibraryManagement.Application.Dtos.Books;
using LibraryManagement.Domain.Entities;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands.CreateBookCommand
{
    internal class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, BookResponseDto>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateBookCommandHandler(
            IBookRepository bookRepository,
            IUnitOfWork unitOfWork,
            IMapper mapper
        )
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<BookResponseDto> Handle(
            CreateBookCommand request,
            CancellationToken cancellationToken
        )
        {
            var book = Book.Create(request.Title, request.PublicationYear);
            book.AssignAuthor(request.AuthorId);

            await _bookRepository.AddAsync(book);

            await _unitOfWork.SaveChangesAsync();

            return _mapper.Map<BookResponseDto>(book);
        }
    }
}
