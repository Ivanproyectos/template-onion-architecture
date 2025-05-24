using AutoMapper;
using LibraryManagement.Application.Dtos.Author;
using LibraryManagement.Domain.Entities;

namespace LibraryManagement.Application.Mappers
{
    internal class AuthorProfile: Profile
    {
        public AuthorProfile()
        {
            CreateMap<Author, AuthorResponseDto>();

        }
    }
}
