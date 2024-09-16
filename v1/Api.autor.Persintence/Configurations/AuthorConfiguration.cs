using Api.autor.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Api.autor.Persintence.Configurations
{
    internal class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(100);

            builder.Property(x => x.Email)
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(x => x.Country)
                .IsRequired()
                .HasMaxLength(100);

            builder.HasIndex(x => x.Email).IsUnique();

            builder.Property(x => x.CreatedAt)
                .IsRequired()
                .HasDefaultValueSql("GETDATE()");

            builder.Property(x => x.CreatedBy)
                .HasMaxLength(100)
                .IsRequired(false);

            builder.Property(x => x.UpdatedBy)
               .HasMaxLength(100)
               .IsRequired(false);

            builder.Property(x => x.UpdatedAt)
                .IsRequired(false);

            builder.HasMany(a => a.Books)
                 .WithOne(b => b.Author)
                 .HasForeignKey(b => b.IdAuthor)
                 .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
