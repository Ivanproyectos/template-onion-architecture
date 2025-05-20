using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Dtos.Book
{
    public record struct BookDto
    {
        public int PublicationYear { get; set; }
        public string Title { get; set; }

    }
}
