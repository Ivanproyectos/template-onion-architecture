using LibraryManagement.Application.Interfaces.External;
using LibraryManagement.Application.Interfaces.Services;
using LibraryManagement.ApplicationServices.External;
using LibraryManagement.ApplicationServices.Services;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Application
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<IExternalApiClient, ExternalApiClient>();
            return services;
        }
    }
}
