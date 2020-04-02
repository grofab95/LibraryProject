using Library.Configs;
using Library.Domain.Entities;
using Library.MsSqlPersistance.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Library.MsSqlPersistance
{
    public class LibraryContext : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrow> BookBorrows { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Config.Get().DbConection);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new AccountTypeConfiguration());
            modelBuilder.ApplyConfiguration(new BookCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new BookBorrowConfiguration());
        }
    }
}

