using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class Book : BaseEntity
    {
        public string Title { get; set; }
        public int PublicationYear { get; set; }
        public int AuthorId { get; set; }
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
    }
}
