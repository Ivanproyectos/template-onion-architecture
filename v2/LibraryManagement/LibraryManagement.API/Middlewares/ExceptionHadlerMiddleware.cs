using System.Net;
using System.Text.Json;
using LibraryManagement.Application.Dtos.Common;
using LibraryManagement.Application.Exceptions;

namespace LibraryManagement.API.Middlewares
{
    public class ExceptionHadlerMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IHostEnvironment _env;

        //private readonly ILoggerService _loggerService;

        public ExceptionHadlerMiddleware(RequestDelegate next, IHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception error)
            {
                if (error is AggregateException aggregateException)
                {
                    error =
                        aggregateException.Flatten().InnerExceptions.FirstOrDefault()
                        ?? aggregateException;
                }

                var result = new ProblemDetailsDto();
                context.Response.ContentType = "application/json";
                switch (error)
                {
                    case ValidationException ex:
                        context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
                        result.Title = "Error de validacion";
                        result.Detail = ex.Message;
                        result.InvalidParams = ex.Failures;
                        break;
                    case KeyNotFoundException ex:
                        result.Title = ex.Message;
                        context.Response.StatusCode = (int)HttpStatusCode.NotFound;
                        break;
                    case UnauthorizedException ex:
                        result.Title = "Unauthorized";
                        result.Detail = ex.Message;
                        context.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                        break;
                    default:

                        result.Title = "Error interno del servidor";
                        result.Detail = _env.IsDevelopment()
                            ? error.Message
                            : "Consulte al administrador del sistema";
                        context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                        //_loggerService.LogError(error.Message, error);
                        break;
                }

                result.Status = context.Response.StatusCode;

                var options = new JsonSerializerOptions
                {
                    // Configurar para que los nombres de las propiedades se serialicen en camelCase
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                };

                var json = JsonSerializer.Serialize(result, options);
                await JsonSerializer.SerializeAsync(context.Response.Body, result, options);
            }
        }
    }
}
