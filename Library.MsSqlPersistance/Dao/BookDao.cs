using Library.Api.Adapters;
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
            if (_context.Books.Any(x => x.Title == book.Title))
            {
                throw new BookTitleAlreadyTaken(book.Title);
            }

            _context.Books.Add(book);
            _context.SaveChanges();
            return book;
        }

        public void Delete(int id)
        {
            var book = _context.Books.Find(id);
            if (book != null)
            {
                _context.Remove(book);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Book> GetAll()
        {
            return _context.Books;
        }

        public Book GetById(int id)
        {
            return _context.Books.Find(id);
        }

        public void Update(Book book)
        {
            var bookDB = _context.Books.Find(book.Id);
            bookDB.ImageId = book.ImageId;

            if (bookDB == null)
            {
                throw new LibraryException("Book not found");
            }

            if (!string.IsNullOrWhiteSpace(book.Title) && book.Title != bookDB.Title)
            {
                if (_context.Books.Any(x => x.Title == book.Title))
                {
                    throw new LibraryException($"Book title: {book.Title} is already taken");
                }
                bookDB.Title = book.Title;
            }

            if (!string.IsNullOrWhiteSpace(book.Author) && book.Author != bookDB.Author)
            {
                if (_context.Books.Any(x => x.Author == book.Author))
                {
                    throw new LibraryException($"Book author: {book.Author} is already taken");
                }
                bookDB.Author = book.Author;
            }
            _context.Books.Update(bookDB);
            _context.SaveChanges();
        }
    }
}
