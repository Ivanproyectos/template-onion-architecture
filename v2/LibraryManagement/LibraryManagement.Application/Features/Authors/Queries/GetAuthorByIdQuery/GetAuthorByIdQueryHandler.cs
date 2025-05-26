using AutoMapper;
using LibraryManagement.Application.Dtos.Author;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Queries.GetAuthorByIdQuery
{
    internal class GetAuthorByIdQueryHandler
        : IRequestHandler<GetAuthorByIdQuery, AuthorResponseDto>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAuthorByIdQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
        }

        public async Task<AuthorResponseDto> Handle(
            GetAuthorByIdQuery request,
            CancellationToken cancellationToken
        )
        {
            var author = await _authorRepository.GetAsync(request.Id);
            if (author == null)
            {
                throw new KeyNotFoundException($"Author with id {request.Id} not found");
            }

            return _mapper.Map<AuthorResponseDto>(author);
        }
    }
}
