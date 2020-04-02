using Library.Domain.Entities;
using Library.Domain.Enums;
using Library.MsSqlPersistance;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Library.ConsoleApp
{
    class Program
    {
        static LibraryContext _context = new LibraryContext();

        static void AddBookCategories()
        {
            var existing = _context.BookCategories.ToList();
            var data = new List<BookCategory>();

            foreach (var bookCategoryName in Enum.GetValues(typeof(BookCategoryName)))
            {
                var bookCategory = new BookCategory((BookCategoryName)bookCategoryName);
                var isExist = existing.Any(x => x.Name == bookCategory.Name);

                if (!isExist)
                {
                    data.Add(bookCategory);
                }
            }


            _context.BookCategories.AddRange(data);
            _context.SaveChanges();
        }

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

        static void AddBooksFromJson()
        {
            var file = File.ReadAllText("data/library-books.txt");
            var books = JsonUtility.ParseToObject<List<Book>>(file);

            _context.Books.AddRange(books);
            _context.SaveChanges();
        }

        static void UpdateBooksCategories()
        {
            var books = _context.Books.ToList();
            var booksCategories = _context.BookCategories.ToList();

            books[0].BookCategory = booksCategories.First(x => x.Name == BookCategoryName.Astronomia);
            books[1].BookCategory = booksCategories.First(x => x.Name == BookCategoryName.Fantastyka);
            books[2].BookCategory = booksCategories.First(x => x.Name == BookCategoryName.Zdrowie);
            books[3].BookCategory = booksCategories.First(x => x.Name == BookCategoryName.Historia);
            books[4].BookCategory = booksCategories.First(x => x.Name == BookCategoryName.Humor);
            books[5].BookCategory = booksCategories.First(x => x.Name == BookCategoryName.Astronomia);
            books[6].BookCategory = booksCategories.First(x => x.Name == BookCategoryName.Informatyka);

            _context.SaveChanges();
        }

        static void Main()
        {
            var userBorrows = _context.BookBorrows
                .Include(y => y.Book)
                .ThenInclude(y => y.BookCategory)
                .Where(x => x.User.Id == 1)
                .ToList();
        }

        static void BorrowBook()
        {
            var user = _context.Users.First(x => x.Email == "qw@qw");
            var books = _context.Books.ToList();

            var borrow = new BookBorrow
            {
                Book = books.First(x => x.Title == "React Native w akcji"),
                User = user,
                RentDate = DateTime.Now,
                BorrowCreatorId = 0
            };

            _context.BookBorrows.Add(borrow);
            _context.SaveChanges();            
        }
    }
}
