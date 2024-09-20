using Api.autor.Application.Interfaces.Exceptions;
using Api.autor.ExceptionHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Api.autor.IoC
{
    public static class WebApplicationConfig
    {
        public static void ConfigureWebApplication(this WebApplication app)
        {
            app.UseExceptionHandler(builder =>
                    builder.UseWebExceptionHandlerMiddleware(
                        app.Environment,
                        app.Services.GetService<IWebExceptionHandler>()!));
        }
    }
}
