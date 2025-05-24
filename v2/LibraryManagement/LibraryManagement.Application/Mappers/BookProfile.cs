using AutoMapper;
using LibraryManagement.Application.Dtos.Books;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Mappers
{
    internal class BookProfile : Profile
    {
        public BookProfile()    
        {
            CreateMap<Book, BookResponseDto>();
        }
    }
}
