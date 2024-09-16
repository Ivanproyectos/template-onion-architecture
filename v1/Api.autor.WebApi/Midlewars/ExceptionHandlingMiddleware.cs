using FluentValidation;

namespace Api.autor.WebApi.Midlewars
{
    public class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlingMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            //catch (ProductoNoDisponibleException ex)
            //{
            //    context.Response.StatusCode = StatusCodes.Status400BadRequest;
            //    await context.Response.WriteAsync(ex.Message);
            //}
            //catch (EmailServiceException ex)
            //{
            //    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            //    await context.Response.WriteAsync("Error al enviar el email.");
            //}
            //catch (RepositorioException ex)
            //{
            //    context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            //    await context.Response.WriteAsync("Error en el repositorio de datos.");
            //}
            catch (ValidationException ex)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                var result = new ProblemDetails(ex.Message, ex.Errors.Select(x => x.ErrorMessage).ToList());
                await context.Response.WriteAsJsonAsync(result);
                //await context.Response.WriteAsync("Ocurrió un error inesperado.");
            }
            catch (Exception ex)
            {
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync("Ocurrió un error inesperado.");
            }
        }
    }
}
public record struct ProblemDetails(string title, List<string> Details);
