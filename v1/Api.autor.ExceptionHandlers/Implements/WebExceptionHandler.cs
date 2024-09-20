using Api.autor.Application.Interfaces.Exceptions;
using Api.autor.Application.Models.Constants;
using Api.autor.Application.Models.Dtos.Exceptions;
using System.Reflection;

namespace Api.autor.ExceptionHandlers.Implements
{
    public class WebExceptionHandler : IWebExceptionHandler
    {
        readonly static Dictionary<Type, Type> ExceptionHandlers = new();

        public WebExceptionHandler(Assembly assembly)
        {
            Type[] types = assembly.GetTypes();
            foreach (Type type in types)
            {
                var Handlers = type.GetInterfaces()
                    .Where(i =>
                      i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IExceptionHandler<>));
                foreach (Type Handler in Handlers)
                {
                    var ExceptionType = Handler.GetGenericArguments()[0];
                    ExceptionHandlers.TryAdd(ExceptionType, type);
                }
            }
        }

        public async ValueTask<ProblemDetailsDto> Handle(Exception ex, bool includeDetails)
        {
            ProblemDetailsDto Problem;

            if (ExceptionHandlers.TryGetValue(ex.GetType(), out Type HandlerType))
            {
                var Handler = Activator.CreateInstance(HandlerType);

                Problem = await (ValueTask<ProblemDetailsDto>)HandlerType.GetMethod(
                                nameof(IExceptionHandler<Exception>.Handle))?
                                .Invoke(Handler, new object[] { ex })!;

                if (!includeDetails)
                {
                    Problem.Detail = "Consulte al administrador.";
                }
            }
            else
            {
                // No encontro el manejador
                string Title;
                string Detail;
                if (includeDetails)
                {
                    Title = $"Un error ocurrió: {ex.Message}";
                    Detail = ex.ToString();
                }
                else
                {
                    Title = "Ha ocurrido un error al procesar la respuesta";
                    Detail = "Consulte al administrador";
                }

                Problem = new ProblemDetailsDto
                {
                    Status = StatusCodesConst.Status500InternalServerError,
                    Type = StatusCodesConst.Status500InternalServerErrorType,
                    Title = Title,
                    Detail = Detail
                };
            }
            return Problem;
        }
    }
}
