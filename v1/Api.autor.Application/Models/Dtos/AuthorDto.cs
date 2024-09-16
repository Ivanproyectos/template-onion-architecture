namespace Api.autor.Application.Models.Dtos
{
    public record struct AuthorDto(int Id,
        string Name,
        string Country,
        string Email, ICollection<BookDto> Books);

}
