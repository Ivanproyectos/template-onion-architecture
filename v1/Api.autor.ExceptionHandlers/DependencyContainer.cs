using Api.autor.Application.Interfaces.Exceptions;
using Api.autor.ExceptionHandlers.Implements;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Reflection;

namespace Api.autor.ExceptionHandlers
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddWebExceptionHandler(
            this IServiceCollection services, Assembly exceptionHandlerAsembly)
        {
            services.AddSingleton<IWebExceptionHandler>(provider =>
                        new WebExceptionHandler(exceptionHandlerAsembly));

            return services;
        }

        public static IServiceCollection AddWebExceptionHandler(
            this IServiceCollection services) =>
            AddWebExceptionHandler(services, Assembly.GetExecutingAssembly());

        public static IApplicationBuilder UseWebExceptionHandlerMiddleware(
            this IApplicationBuilder app, IHostEnvironment enviroment,
            IWebExceptionHandler handler)
        {
            app.Use((context, next) =>
                  WebExceptionHandlerMiddleware.WriteResponse(
                      context, enviroment.IsDevelopment(), handler));

            return app;
        }

    }
}
