using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Library.MsSqlPersistance
{
    public class LibraryContext : DbContext
    {
        //public LibraryContext(DbContextOptions<LibraryContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<BookCategory> BookCategories { get; set; }   
        public DbSet<Book> Books { get; set; }
        public DbSet<BookBorrow> BookBorrows { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }
        public DbSet<AccountType> AccountTypes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=SRV_2016\\SQLEXPRESS;Database=LIBRARY_NEW;User Id=sa; Password=Q1w2e3;");
        }
    }

    //public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<LibraryContext>
    //{
    //    public LibraryContext CreateDbContext(string[] args)
    //    {
    //        IConfigurationRoot configuration = new ConfigurationBuilder()
    //            .SetBasePath(Directory.GetCurrentDirectory())
    //            .AddJsonFile(@Directory.GetCurrentDirectory() + "/../Library.API/appsettings.json")
    //            .Build();
    //        var builder = new DbContextOptionsBuilder<LibraryContext>();
    //        var connectionString = configuration.GetConnectionString("DatabaseConnection");
    //        builder.UseSqlServer(connectionString);
    //        return new LibraryContext(builder.Options);
    //    }
    //}
}
