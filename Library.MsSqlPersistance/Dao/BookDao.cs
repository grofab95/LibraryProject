using Library.Domain.Adapters;
using Library.Domain.Entities;
using Library.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Library.MsSqlPersistance.Dao
{
    public class BookDao : IBookDao
    {
        private LibraryContext _context;

        public BookDao(LibraryContext context)
        {
            _context = context;
        }

        public Book Create(Book book)
        {
            if (string.IsNullOrEmpty(book.Title))
            {
                throw new EmptyField("tytuł");
            }

            if (book.BookAuthor == null)
            {
                throw new EmptyField("autor");
            }

            if (book.BookCategory == null)
            {
                throw new EmptyField("kateogira");
            }

            if (_context.Books.Any(x => x.Title == book.Title))
            {
                throw new BookTitleAlreadyTaken(book.Title);
            }

            _context.Add(book);
            _context.SaveChanges();

            return book;
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books
                 .Select(x => new Book
                 {
                     BookId = x.BookId,
                     Title = x.Title,
                     BookAuthor = x.BookAuthor,
                     BookCategory = x.BookCategory,
                     Amount = x.Amount,
                     Description = x.Description
                 });
        }

        public Book GetById(int id)
        {
            return _context.Books
                .Select(x => new Book
                {
                    BookId = x.BookId,
                    Title = x.Title,
                    BookAuthor = x.BookAuthor,
                    BookCategory = x.BookCategory,
                    Amount = x.Amount,
                    Description = x.Description
                })
                .FirstOrDefault(y => y.BookId == id);
        }

        public void Update(Book book)
        {
            var bookDb = _context.Books.FirstOrDefault(x => x.BookId == book.BookId)
                ?? throw new BookNotExist(book.Title);

            bookDb = book;
            _context.SaveChanges();
        }
    }
}
