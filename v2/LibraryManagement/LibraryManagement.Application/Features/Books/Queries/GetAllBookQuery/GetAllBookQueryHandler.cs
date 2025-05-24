using AutoMapper;
using LibraryManagement.Application.Dtos.Books;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Books.Queries.GetAllBookQuery
{
    internal class GetAllBookQueryHandler : IRequestHandler<GetAllBookQuery, List<BookResponseDto>>
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;

        public GetAllBookQueryHandler(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookResponseDto>> Handle(
            GetAllBookQuery request,
            CancellationToken cancellationToken
        )
        {
            var books = await _bookRepository.GetAllAsync();
            return _mapper.Map<List<BookResponseDto>>(books);
        }
    }
}
