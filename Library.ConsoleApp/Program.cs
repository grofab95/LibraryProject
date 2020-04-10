using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.MsSqlPersistance;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library.ConsoleApp
{
    class Pass
    {
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
    }

    class Program
    {
        static LibraryContext _context = new LibraryContext();

        static void AddAccountsTypes()
        {
            var existing = _context.AccountTypes.ToList();
            var data = new List<AccountType>();

            foreach (var accountTypeName in Enum.GetValues(typeof(AccountTypeName)))
            {
                var accountType = new AccountType((AccountTypeName)accountTypeName);
                var isExist = existing.Any(x => x.Name == accountType.Name);

                if (!isExist)
                {
                    data.Add(accountType);
                }
            }

            _context.AccountTypes.AddRange(data);
            _context.SaveChanges();
        }

        static void AddFactors()
        {

            var bookCategories = new List<BookCategory>()
            {
                new BookCategory { Name = "Fantastyka" },
                new BookCategory { Name = "Hobby" },
                new BookCategory { Name = "Zdrowie" },
                new BookCategory { Name = "Astronomia" },
                new BookCategory { Name = "Humor" },
                new BookCategory { Name = "Informatyka" },
                new BookCategory { Name = "Kultura" },
                new BookCategory { Name = "Historia" }
            };

            var authors = new List<BookAuthor>()
            {
                new BookAuthor { Name = "J. K.", Surname = "Rowling" },
                new BookAuthor { Name = "Marco", Surname = "Bersanelli" },
                new BookAuthor { Name = "Thomas", Surname = "Dormandy" },
                new BookAuthor { Name = "Szymon", Surname = "Wrzesiński" },
                new BookAuthor { Name = "Mariusz", Surname = "Kolmasiak" },
                new BookAuthor { Name = "Dimitris", Surname = "Chassapakis" },
                new BookAuthor { Name = "Dabit", Surname = "Nader" },
                new BookAuthor { Name = "Robert C.", Surname = "Martin" },
            };


            _context.BookCategories.AddRange(bookCategories);
            _context.BookAuthors.AddRange(authors);

            _context.SaveChanges();
        }

        static void AddBooksFromJSon()
        {
            var json = File.ReadAllText("data/library-books.txt");
            var books = JsonConvert.DeserializeObject<List<Book>>(json);

            _context.Books.AddRange(books);
            _context.SaveChanges();
        }

        static Pass GetHashed(string password)
        {
            byte[] passwordHash, passwordSalt;
            PasswordHash.CreatePasswordHash(password, out passwordHash, out passwordSalt);

            return new Pass
            {
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
        }

        static void AddUsers()
        {
            var users = new List<User>();

            var user = new User();

            users.Add(new User
            {
                Name = "Fabian",
                Surname = "Grochla",
                Email = "qw@qw",
                AccountTypeId = 1
            });

            users.Add(new User
            {
                Name = "Marian",
                Surname = "Prosty",
                Email = "prosty@krzywy",
                AccountTypeId = 3
            });

            users.Add(new User
            {
                Name = "Kasia",
                Surname = "Nowak",
                Email = "nowak@test",
                AccountTypeId = 2
            });

            users.Add(new User
            {
                Name = "Andrzej",
                Surname = "Kowalski",
                Email = "kowalski@domain",
                AccountTypeId = 3
            });

           

            _context.Users.AddRange(users);
            _context.SaveChanges();
        }

        static void AddBorrows()
        {
            var borrows = new List<BookBorrow>
            {
                new BookBorrow
                {
                    UserId = 1,
                    BookId = 2,
                    RentDate = DateTime.Now
                },
                new BookBorrow
                {
                    UserId = 2,
                    BookId = 5,
                    RentDate = DateTime.Now
                },
                new BookBorrow
                {
                    UserId = 2,
                    BookId = 3,
                    RentDate = DateTime.Now
                },
                new BookBorrow
                {
                    UserId = 3,
                    BookId = 5,
                    RentDate = DateTime.Now
                },
                new BookBorrow
                {
                    UserId = 3,
                    BookId = 6,
                    RentDate = DateTime.Now
                },
                new BookBorrow
                {
                    UserId = 2,
                    BookId = 3,
                    RentDate = DateTime.Now
                },
            };

            _context.BookBorrows.AddRange(borrows);
            _context.SaveChanges();
        }

        static void AddObjects()
        {
            //AddAccountsTypes();
            //AddFactors();
            //AddBooksFromJSon();
            //AddUsers();
            AddBorrows();
        }

        static void Main()
        {

            AddObjects();


            var users = _context.Users
                .Select(x => new
                {
                    UserID = x.UserId,
                    Name = x.Name,
                    Surname = x.Surname,
                    Email = x.Email,
                    Role = x.AccountType.Name,
                    Borrow = x.BookBorrows
                        .Where(y => y.UserId == x.UserId)
                        .Select(z => new
                        {
                            Title = z.Book.Title,
                            Author = $"{z.Book.BookAuthor.Name} {z.Book.BookAuthor.Surname}",
                            Description = z.Book.Description,
                            Category = z.Book.BookCategory.Name
                        })
                        .ToList()

                })
                .ToList();
        }
    }
}
