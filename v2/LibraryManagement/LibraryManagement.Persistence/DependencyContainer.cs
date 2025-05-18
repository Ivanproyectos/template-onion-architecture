using LibraryManagement.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Persistence
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<MysqlContext>(options =>
          {
              options.UseMySql(configuration.GetConnectionString("DefaultConnection"),
                  ServerVersion.AutoDetect(configuration.GetConnectionString("DefaultConnection")));
          });

            return services;
        }
    }
}
