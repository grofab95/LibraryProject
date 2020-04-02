using Library.Domain.Entities;
using Library.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Library.MsSqlPersistance.Configurations
{
    class BookCategoryConfiguration : IEntityTypeConfiguration<BookCategory>
    {
        public void Configure(EntityTypeBuilder<BookCategory> builder)
        {
            builder.ToTable("BookCategories");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasConversion(x => x.ToString(), y => (BookCategoryName)Enum.Parse(typeof(BookCategoryName), y))
                .HasColumnName("Name");

            builder.HasMany(x => x.Books)
                .WithOne(x => x.BookCategory)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
