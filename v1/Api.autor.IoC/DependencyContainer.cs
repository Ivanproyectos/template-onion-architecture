using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.autor.Persintence;
using Api.autor.Application;
using Api.autor.Shared;
using Microsoft.Extensions.Hosting;
using Api.autor.ExceptionHandlers;

namespace Api.autor.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddAuhorIoC(this IServiceCollection services,
            IHostBuilder hostBuilder, IConfiguration configuration)
        {
            services.AddWebExceptionHandler();
            services.AddShared(hostBuilder);
            services.AddPersistenceInfraestructure(configuration)
                .AddApplication();
            return services;
        }
    }
}
