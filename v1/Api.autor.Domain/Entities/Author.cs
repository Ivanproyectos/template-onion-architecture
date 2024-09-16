using Api.autor.Domain.Common;
using System.Collections;

namespace Api.autor.Domain.Entities
{
    public class Author : AuditableEntity
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
        public ICollection<Book> Books { get; set; }
    }
}
