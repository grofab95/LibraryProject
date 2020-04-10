using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Library.MsSqlPersistance.Configurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(x => x.UserId);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()");

            builder.HasMany(x => x.BookBorrows)
                .WithOne(x => x.User)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(x => x.AccountType)
                .WithMany(x => x.Users)
                .IsRequired()
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}