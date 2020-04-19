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

            book.BookAuthorId = book.BookAuthor.BookAuthorId;
            book.BookCategoryId = book.BookCategory.BookCategoryId;
            book.BookAuthor = null;
            book.BookCategory = null;

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
                     Description = x.Description,
                     ImageId = x.ImageId
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

            bookDb.Title = book.Title;
            bookDb.BookAuthorId = book.BookAuthor.BookAuthorId;
            bookDb.BookCategoryId = book.BookCategory.BookCategoryId;
            bookDb.Description = book.Description;
            bookDb.ImageId = book.ImageId;

            _context.SaveChanges();
        }
    }
}
