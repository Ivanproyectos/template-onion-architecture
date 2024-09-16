using Api.autor.Application.Models.Dtos;
using Api.autor.Domain.Interfaces.Repositories;
using AutoMapper;
using MediatR;

namespace Api.autor.Application.Features.Autor.Querys
{
    public class GetAllAuthorsQuery: IRequest<List<AuthorDto>>
    {
        public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, List<AuthorDto>>
        {
            private readonly IAuthorRepository _authorRepository;
            private readonly IMapper _mapper;
            public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper)
            {
                _authorRepository = authorRepository;
                _mapper = mapper;
            }
            public async Task<List<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
            {
                var authors = await _authorRepository.GetAllAuthorsAync();

                return _mapper.Map<List<AuthorDto>>(authors);
            }
        }
    }
}
