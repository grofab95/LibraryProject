using Library.Domain.Entities;
using Library.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace Library.MsSqlPersistance.Configurations
{
    public class AccountTypeConfiguration : IEntityTypeConfiguration<AccountType>
    {
        public void Configure(EntityTypeBuilder<AccountType> builder)
        {
            builder.ToTable("AccountTypes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                .IsRequired()
                .HasConversion(x => x.ToString(), y => (AccountTypeName)Enum.Parse(typeof(AccountTypeName), y))
                .HasColumnName("Name");

            builder.HasMany(x => x.Users)
                .WithOne(x => x.AccountType)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }
}
