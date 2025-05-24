using AutoMapper;
using LibraryManagement.Domain.Interfaces;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Commands.UpdateBookCommand
{
    internal class UpdateBookCommandHandler : IRequestHandler<UpdateBookCommand, Unit>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IUnitOfWork _unitOfWork;

        public UpdateBookCommandHandler(
            IBookRepository bookRepository,
            IUnitOfWork unitOfWork
        )
        {
            _bookRepository = bookRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<Unit> Handle(
            UpdateBookCommand request,
            CancellationToken cancellationToken
        )
        {
            var book = await _bookRepository.GetAsync(request.Id);

            if (book == null)
            {
                throw new Exception("Book not found");
            }

            book.UpdateDetails(request.AuthorId, request.Title, request.PublicationYear);

            await _bookRepository.UpdateAsync(book);
            await _unitOfWork.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
