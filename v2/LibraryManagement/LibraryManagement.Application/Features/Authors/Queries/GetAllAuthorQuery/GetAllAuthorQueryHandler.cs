using AutoMapper;
using LibraryManagement.Application.Dtos.Author;
using LibraryManagement.Domain.Interfaces.Repositories;
using MediatR;

namespace LibraryManagement.Application.Features.Authors.Queries.GetAllAuthorQuery
{
    internal class GetAllAuthorQueryHandler : IRequestHandler<GetAllAuthorQuery, List<AuthorResponseDto>>
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;

        public GetAllAuthorQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
        {   
            _authorRepository = authorRepository;
            _mapper = mapper;
        }
        
        public  async Task<List<AuthorResponseDto>> Handle(GetAllAuthorQuery request, CancellationToken cancellationToken)
        {
            var authors = await _authorRepository.GetAllAsync();

            return _mapper.Map<List<AuthorResponseDto>>(authors);
        }
    }
}
