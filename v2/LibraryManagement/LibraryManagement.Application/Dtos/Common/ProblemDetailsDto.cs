using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Dtos.Common
{
    public record struct ProblemDetailsDto(
        int Status,
        string Type,
        string Title,
        string Detail,
        Dictionary<string, List<string>> InvalidParams
    );
}
