using Api.autor.Application.Interfaces.Services;
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
            private readonly ILoggerService<GetAllAuthorsQueryHandler> _logger;
            public GetAllAuthorsQueryHandler(IAuthorRepository authorRepository, IMapper mapper, ILoggerService<GetAllAuthorsQueryHandler> logger)
            {
                _authorRepository = authorRepository;
                _mapper = mapper;
                _logger = logger;
            }
            public async Task<List<AuthorDto>> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
            {
                var authors = await _authorRepository.GetAllAuthorsAync();
                _logger.LogError("no see que pasoo", new Exception("xd"));

                return _mapper.Map<List<AuthorDto>>(authors);
            }
        }
    }
}
