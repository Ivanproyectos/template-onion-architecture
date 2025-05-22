namespace LibraryManagement.Application.Dtos.Books
{
    public record struct BookResponse(
        int Id,
        string Title,
        string PublicationYear)
    {
    }
}
