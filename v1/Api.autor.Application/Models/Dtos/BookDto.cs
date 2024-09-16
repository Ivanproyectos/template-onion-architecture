using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.autor.Application.Models.Dtos
{
    public record struct BookDto(
        int Id,
        string Title,
        string Description);
}
