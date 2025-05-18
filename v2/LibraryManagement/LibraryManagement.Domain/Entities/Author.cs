using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Domain.Entities
{
    public class Author: BaseEntity
    {
        public string Name { get; private set; }
        public string Nationality { get; private set; }

        private readonly List<Book> _books = new();
        public IReadOnlyCollection<Book> Books => _books.AsReadOnly();

        private Author() { } // Para EF Core u otros ORMs

        private Author(string name, string nationality)
        {
            Name = name;
            Nationality = nationality;
        }

        public static Author Create(string name, string nationality)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("El nombre es obligatorio.", nameof(name));

            return new Author(name, nationality);
        }

        public void AddBook(string title, int year)
        {
            var book = Book.Create(title, year);
            _books.Add(book);
        }

    }
}
