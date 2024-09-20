using Api.autor.Application.Models.Dtos.Exceptions;

namespace Api.autor.Application.Interfaces.Exceptions
{
    public interface IExceptionHandler<ExeptionType> where ExeptionType : Exception
    {
        ValueTask<ProblemDetailsDto> Handle(ExeptionType exception);
    }
}
