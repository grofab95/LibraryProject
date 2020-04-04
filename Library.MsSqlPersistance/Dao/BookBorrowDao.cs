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

        public int Create(BookBorrow bookBorrow, int userId, int bookId)
        {
            bookBorrow.User = _context.Users.FirstOrDefault(x => x.Id == userId)
                ?? throw new Exception($"Użytkownik id: {userId} nie istnieje");
            bookBorrow.Book = _context.Books.FirstOrDefault(x => x.Id == bookId)
                ?? throw new Exception($"Książka id: {bookId} nie istnieje");
            bookBorrow.Book.Amount--;
            bookBorrow.IsBookReturned = false;
            _context.BookBorrows.Add(bookBorrow);
            _context.SaveChanges();
            return bookBorrow.Id;
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

        public IEnumerable<BookBorrow> GetByUserEmail(string email)
        {
            return _context.BookBorrows
                .Include(x => x.User)
                .Include(x => x.Book)
                    .ThenInclude(x => x.BookCategory)
                .Where(y => y.User.Email == email);
                
        }

        public IEnumerable<BookBorrow> GetAll()
        {
            return _context.BookBorrows
                .Include(x => x.User)
                .Include(x => x.Book);
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
                throw new LibraryException($"Brak wypożyczenia o id: {bookBorrow.Id}");
            }
            bookBorrowDb.IsBookReturned = bookBorrow.IsBookReturned;
            _context.BookBorrows.Update(bookBorrowDb);
            _context.SaveChanges();
        }
    }
}
