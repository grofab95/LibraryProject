using Library.Domain.Adapters;
using Library.Domain.Entities;
using Library.Exceptions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.MsSqlPersistance.Dao
{
    public class BookBorrowDao : IBookBorrowDao
    {
        private LibraryContext _context;

        public BookBorrowDao(LibraryContext context)
        {
            _context = context;
        }

        public int CreateBorrow(BookBorrow borrow)
        {
            var user = _context.Users.FirstOrDefault(x => x.UserId == borrow.UserId)
                ?? throw new UserNotExist(borrow.UserId);

            var book = _context.Books.FirstOrDefault(x => x.BookId == borrow.BookId)
                ?? throw new BookNotExist(borrow.BookId);

            var isBookAvailable = book.Amount > 0;

            if (isBookAvailable == false)
            {
                throw new BookNotAvailable(book.Title);
            }

            var isBorrowExit = _context.BookBorrows
                .Any(x => x.UserId == borrow.UserId && x.BookId == borrow.BookId);

            if (isBorrowExit)
            {
                throw new BookBorredAlreadyTaken(borrow.UserId, borrow.BookId);
            }

            book.Amount--;

            _context.BookBorrows.Add(borrow);
            _context.SaveChanges();
            return borrow.BookBorrowId;
        }

        public void ReturnBook(int borrowId)
        {
            var borrow = GetByBorrowId(borrowId);
            borrow.IsBookReturned = true;
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BookBorrow> GetAll()
        {
            return _context.BookBorrows
                .Select(x => new BookBorrow
                {
                    BookBorrowId = x.BookBorrowId,
                    Book = x.Book,
                    User = x.User
                });
        }

        public BookBorrow GetByBorrowId(int id)
        {
            return _context.BookBorrows
                .Include(z => z.Book.BookCategory)
                .Include(z => z.Book.BookAuthor)
                .Select(x => new BookBorrow
                {
                    BookBorrowId = x.BookBorrowId,
                    Book = x.Book,
                    User = x.User,
                    UserId = x.UserId
                })
                .FirstOrDefault(y => y.BookBorrowId == id);
        }

        public IEnumerable<BookBorrow> GetByUserId(int id)
        {
            return _context.BookBorrows
                .Include(z => z.Book.BookCategory)
                .Include(z => z.Book.BookAuthor)
                .Select(x => new BookBorrow
                {
                    BookBorrowId = x.BookBorrowId,
                    Book = x.Book,
                    User = x.User,
                    UserId = x.UserId
                })
                .Where(y => y.UserId == id);
        }

        public void Update(BookBorrow borrow)
        {
            throw new NotImplementedException();
        }
    }
}
