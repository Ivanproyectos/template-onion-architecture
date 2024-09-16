using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Api.autor.Persintence;
using Api.autor.Application;

namespace Api.autor.IoC
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddAuhorIoC(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddPersistenceInfraestructure(configuration)
                .AddApplication();
            return services;
        }
    }
}
