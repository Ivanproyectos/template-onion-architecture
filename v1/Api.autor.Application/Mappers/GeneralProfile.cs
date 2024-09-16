using Api.autor.Application.Models.Dtos;
using Api.autor.Domain.Entities;
using AutoMapper;

namespace Api.autor.Application.Mappers
{
    public class GeneralProfile: Profile
    {
        public GeneralProfile() {
            #region Querys
            CreateMap<Author, AuthorDto>()
             .ForMember(dest => dest.Books, opt => opt.MapFrom(src => src.Books));

            // Mapeo entre Book y BookDto
            CreateMap<Book, BookDto>();
            #endregion
        }
    }
}
