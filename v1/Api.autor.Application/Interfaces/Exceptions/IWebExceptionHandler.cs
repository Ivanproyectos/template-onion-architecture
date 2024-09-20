using Api.autor.Application.Models.Dtos.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.autor.Application.Interfaces.Exceptions
{
    public interface IWebExceptionHandler
    {
        ValueTask<ProblemDetailsDto> Handle(Exception ex, bool includeDetails);
    }
}
