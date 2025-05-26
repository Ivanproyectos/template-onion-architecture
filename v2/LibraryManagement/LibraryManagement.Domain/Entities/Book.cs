namespace LibraryManagement.Domain.Entities
{
    public class Book : Entity
    {
        public string Title { get; private set; }
        public int PublicationYear { get; private set; }
        public int AuthorId { get; private set; }

        private Book() { } // Para EF Core

        private Book(string title, int publicationYear)
        {
            Title = title;
            PublicationYear = publicationYear;
        }

        public static Book Create(string title, int publicationYear)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("El título es obligatorio.", nameof(title));
            if (publicationYear <= 0)
                throw new ArgumentException("El año debe ser válido.", nameof(publicationYear));

            return new Book(title, publicationYear);
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

        public void AssignAuthor(int authorId) => AuthorId = authorId;
    }
}
