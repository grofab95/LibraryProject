using Library.Api.Adapters;
using Library.Api.Entities;
using Library.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.MsSqlPersistance.Dao
{
    public class BookBorrowDao : IBookBorrow
    {
        private DataContext _context;

        public BookBorrowDao(DataContext context)
        {
            _context = context;
        }

        public BookBorrow Create(BookBorrow bookBorrow)
        {
            if (_context.BookBorrows.Any(bookBorrowDb => bookBorrow.UserId == bookBorrow.UserId) &&
                _context.BookBorrows.Any(bookBorrowDb => bookBorrow.BookId == bookBorrow.BookId))
            {
                throw new BookBorredAlreadyTaken(bookBorrow.UserId, bookBorrow.BookId);
            }

            bookBorrow.RentDate = DateTime.Now;
            bookBorrow.IsBookReturned = false;
            _context.BookBorrows.Add(bookBorrow);
            _context.SaveChanges();
            return bookBorrow;
        }

        public void Delete(int id)
        {
            var bookBorrowDb = _context.Books.Find(id);
            if (bookBorrowDb != null)
            {
                _context.Remove(bookBorrowDb);
                _context.SaveChanges();
            }
        }

        public IEnumerable<BookBorrow> GetAll()
        {
            return _context.BookBorrows;
        }

        public BookBorrow GetById(int id)
        {
            return _context.BookBorrows.Find(id);
        }

        public void Update(BookBorrow bookBorrow)
        {
            var bookBorrowDb = _context.BookBorrows.Find(bookBorrow.Id);
            if (bookBorrowDb == null)
            {
                throw new LibraryException($"Book bored with id: {bookBorrow.Id} is not exist.");
            }
            bookBorrowDb.IsBookReturned = bookBorrow.IsBookReturned;
            _context.BookBorrows.Update(bookBorrowDb);
            _context.SaveChanges();
        }
    }
}
