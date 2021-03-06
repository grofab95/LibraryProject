﻿using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.MsSqlPersistance.Configurations
{
    public class BookBorrowConfiguration : IEntityTypeConfiguration<BookBorrow>
    {
        public void Configure(EntityTypeBuilder<BookBorrow> builder)
        {
            builder.ToTable("BookBorrows");
            builder.HasKey(x => x.BookBorrowId);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()");

            builder.HasOne(x => x.User)
                .WithMany(x => x.BookBorrows)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.Book)
                .WithMany(x => x.BookBorrows)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
