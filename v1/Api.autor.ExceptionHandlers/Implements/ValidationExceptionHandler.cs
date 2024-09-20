
using Api.autor.Application.Exceptions;
using Api.autor.Application.Interfaces.Exceptions;
using Api.autor.Application.Models.Constants;
using Api.autor.Application.Models.Dtos.Exceptions;

namespace Api.autor.ExceptionHandlers.Implements
{
    public class ValidationExceptionHandler : IExceptionHandler<ValidationException>
    {
        public ValueTask<ProblemDetailsDto> Handle(ValidationException exception)
        {
            return ValueTask.FromResult(
                 new ProblemDetailsDto
                 {
                     Status = StatusCodesConst.Status400BadRequest,
                     Type = StatusCodesConst.Status400BadRequestType,
                     Title = "Error en los datos de entrada.",
                     Detail = "Se encontraron uno o más errores de validación de datos.",
                     InvalidParams = exception.Failures
                 });
        }
    }
}
