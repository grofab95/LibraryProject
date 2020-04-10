using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.MsSqlPersistance.Configurations
{
    public class BookAuthorConfiguration : IEntityTypeConfiguration<BookAuthor>
    {
        public void Configure(EntityTypeBuilder<BookAuthor> builder)
        {
            builder.ToTable("BookAuthors");
            builder.HasKey(x => x.BookAuthorId);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()");
        }
    }
}
