using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.MsSqlPersistance.Configurations
{
    class BookConfiguration : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Books");
            builder.HasKey(x => x.BookId);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.BookBorrows)
                .WithOne(x => x.Book)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.BookCategory)
                .WithMany(x => x.Books)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.BookAuthor)
                .WithMany(x => x.Books)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
