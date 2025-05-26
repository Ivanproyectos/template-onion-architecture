using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LibraryManagement.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace LibraryManagement.Persistence.Configurations
{
    internal class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).ValueGeneratedOnAdd().IsRequired();

            builder.Property(x => x.Title).HasMaxLength(100).IsRequired();

            builder.Property(x => x.AuthorId).IsRequired();

            builder.Property(x => x.PublicationYear).IsRequired();

            builder.Property(x => x.CreatedBy).IsRequired(false);

            builder.Property(x => x.CreatedDate).IsRequired(false);

            builder.Property(x => x.UpdatedDate).IsRequired(false);

            builder.Property(x => x.UpdatedBy).IsRequired(false);
        }
    }
}
