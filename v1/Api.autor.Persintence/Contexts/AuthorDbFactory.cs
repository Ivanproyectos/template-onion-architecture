using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Api.autor.Persintence.Contexts
{
    internal class AuthorDbFactory :
        IDesignTimeDbContextFactory<AuthorDbContext>
    {
        public AuthorDbContext CreateDbContext(string[] args)
        {
            var OptionBuilder =
                  new DbContextOptionsBuilder<AuthorDbContext>();

            OptionBuilder
                .UseSqlServer("Server=(localdb)\\mssqllocaldb;database=authordb");

            return new AuthorDbContext(OptionBuilder.Options);
        }
    }

    //add-migration InitialMigration -p Api.autor.Persintence -s Api.autor.Persintence -c AuthorDbContext
    //update-database InitialMigration -p Api.autor.Persintence -s Api.autor.Persintence -context AuthorDbContext
}
