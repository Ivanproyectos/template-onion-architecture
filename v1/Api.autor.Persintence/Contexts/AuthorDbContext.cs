using Api.autor.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.autor.Persintence.Contexts
{
    public class AuthorDbContext: DbContext
    {
        public AuthorDbContext(DbContextOptions<AuthorDbContext> options): base(options)
        {
            ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AuthorDbContext).Assembly);
        }

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }


    }
}
