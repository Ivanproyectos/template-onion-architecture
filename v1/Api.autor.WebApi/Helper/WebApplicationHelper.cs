using Api.autor.Application.Interfaces.Exceptions;
using Api.autor.ExceptionHandlers;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Api.autor.WebApi.Helper
{
    public static class WebApplicationHelper
    {
        //public static void ConfigureWebApplication(this WebApplication app)
        //{
        //    app.UseExceptionHandler(builder =>
        //            builder.UseWebExceptionHandlerMiddleware(
        //                app.Environment,
        //                app.Services.GetService<IWebExceptionHandler>()!));
        //}

        public static WebApplication ConfigureWebApplication(
        this WebApplication app)
        {
            app.UseExceptionHandler(builder =>
                               builder.UseWebExceptionHandlerMiddleware(
                                   app.Environment,
                                   app.Services.GetService<IWebExceptionHandler>()!));

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            //app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();

            return app;
        }
    }
}
