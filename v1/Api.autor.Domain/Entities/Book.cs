using Api.autor.Domain.Common;

namespace Api.autor.Domain.Entities
{
    public class Book: AuditableEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int IdAuthor { get; set; }
        public Author Author { get; set; }
    }
}
