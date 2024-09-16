using Api.autor.Domain.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Api.autor.Domain.Entities;

namespace Api.autor.Application.Features.Books.Commands
{
    public class CreateBookCommand : IRequest<int>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdAuthor { get; set; }

        public class CreateBookCommandHandler : IRequestHandler<CreateBookCommand, int>
        {
            private readonly IMapper _mapper;
            private readonly IBookRepository _bookRepository;
            private readonly IUnitOfWork _unitOfWork;
            public CreateBookCommandHandler(
                IBookRepository bookRepository,
                IMapper mapper,
                IUnitOfWork unitOfWork)
            {
                _mapper = mapper;
                _bookRepository = bookRepository;
                _unitOfWork = unitOfWork;
            }
            public async Task<int> Handle(CreateBookCommand request, CancellationToken cancellationToken)
            {
                var book = new Book
                {
                    Title = request.Title,
                    Description = request.Description,
                    IdAuthor = request.IdAuthor
                };

                var bookCreated = await _bookRepository.CreateBookAsync(book);
                await _unitOfWork.SaveChangesAsync();

                return bookCreated.Id;
            }
        }
    }
}
