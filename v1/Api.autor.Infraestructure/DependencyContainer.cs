using Api.autor.Application.Interfaces.Services;
using Api.autor.Infraestructure.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Api.autor.Infraestructure
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IHostBuilder hostBuilder)
        {
            hostBuilder.UseSerilog((context, configuration) =>
             configuration.ReadFrom.Configuration(context.Configuration));

            services.AddScoped(typeof(ILoggerService<>), typeof(LogFileService<>));

            return services;
        }
    }
}
