using Api.autor.Domain.Interfaces.Repositories;
using Api.autor.Persintence.Contexts;
using Api.autor.Persintence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Api.autor.Persintence
{
    public static class DependencyContainer
    {
        public static IServiceCollection AddPersistenceInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection");
            //services.AddDbContext<AuthorDbContext>(options => 
            //options.UseSqlServer(connectionString, b => b.MigrationsAssembly(typeof(AuthorDbContext).Assembly.FullName)));

            services.AddDbContext<AuthorDbContext>(options => options.UseSqlServer(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
            return services;
        }
    }
}
