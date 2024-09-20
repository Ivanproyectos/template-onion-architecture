using Api.autor.Application.Interfaces.Exceptions;
using Api.autor.Application.Models.Constants;
using Api.autor.Application.Models.Dtos.Exceptions;

namespace Api.autor.ExceptionHandlers.Implements
{
    public class UnauthorizedAccessExceptionHandler : IExceptionHandler<UnauthorizedAccessException>
    {
        public ValueTask<ProblemDetailsDto> Handle(UnauthorizedAccessException exception)
        {
            return ValueTask.FromResult(
                        new ProblemDetailsDto
                        {
                            Status = StatusCodesConst.Status401Unauthorized,
                            Type = StatusCodesConst.Status401UnauthorizedType,
                            Title = "Error de Authorización",
                            Detail = exception.Message
                        });
        }
    }
}
