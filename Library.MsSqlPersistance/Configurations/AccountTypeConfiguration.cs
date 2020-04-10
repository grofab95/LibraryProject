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
            builder.HasKey(x => x.AccountTypeId);

            builder.Property(x => x.CreatedDate)
                .HasDefaultValueSql("getdate()");

            builder.Property(x => x.Name)
                .IsRequired()
                .HasConversion(x => x.ToString(), y => (AccountTypeName)Enum.Parse(typeof(AccountTypeName), y))
                .HasColumnName("Name");
        }
    }
}
