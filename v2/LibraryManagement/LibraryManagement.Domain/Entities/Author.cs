﻿namespace LibraryManagement.Domain.Entities
{
    public class Author : Entity
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

        public void UpdateDetails(string newName, string newNationality)
        {
            if (string.IsNullOrWhiteSpace(newName))
                throw new ArgumentException("El nombre es obligatorio.", nameof(newName));

            Name = newName;
            Nationality = newNationality;
        }

        public void AddBook(string title, int year)
        {
            var book = Book.Create(title, year);

            book.AssignAuthor(this.Id);

            if (_books.Any(b => b.Title == title && b.PublicationYear == year))
                throw new InvalidOperationException("El libro ya ha sido agregado.");

            _books.Add(book);
        }
    }
}
