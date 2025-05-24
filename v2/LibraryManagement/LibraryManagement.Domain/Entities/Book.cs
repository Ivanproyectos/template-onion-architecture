namespace LibraryManagement.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get;private set; }
        public int PublicationYear { get; private set; }
        public int AuthorId { get; private set; }
        private Book() { } // Para EF Core

        private Book(int authorId, string title, int publicationYear)
        {
            Title = title;
            PublicationYear = publicationYear;
            AuthorId = authorId;
        }

        public static Book Create(int authorId, string title, int publicationYear)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("El título es obligatorio.", nameof(title));
            if (publicationYear <= 0)
                throw new ArgumentException("El año debe ser válido.", nameof(publicationYear));

            return new Book(authorId, title, publicationYear);
        }

        public void UpdateDetails(int authorId, string title, int publicationYear)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("El título es obligatorio.", nameof(title));
            if (publicationYear <= 0)
                throw new ArgumentException("El año debe ser válido.", nameof(publicationYear));

            Title = title;
            PublicationYear = publicationYear;
            AuthorId = authorId;
        }
    }
}
