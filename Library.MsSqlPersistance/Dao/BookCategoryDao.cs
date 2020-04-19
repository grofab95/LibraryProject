using Library.Domain.Adapters;
using Library.Domain.Entities;
using Library.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.MsSqlPersistance.Dao
{
    public class BookCategoryDao : IBookCategoryDao
    {
        private LibraryContext _context;

        public BookCategoryDao(LibraryContext context)
        {
            _context = context;
        }

        public BookCategory Create(BookCategory bookCategory)
        {
            if (string.IsNullOrWhiteSpace(bookCategory.Name))
            {
                throw new EmptyField("category name");
            }

            if (_context.BookCategories.Any(x => x.BookCategoryId == bookCategory.BookCategoryId))
            {
                throw new BookCategoryExist(bookCategory.Name);
            }

            _context.BookCategories.Add(bookCategory);
            _context.SaveChanges();
            return bookCategory;
        }

        public void Delete(int id)
        {
            var category = _context.BookCategories
                .FirstOrDefault(x => x.BookCategoryId == id)
                    ?? throw new BookCategoryNotExist(id);

            _context.BookCategories.Remove(category);
            _context.SaveChanges();
        }

        public IEnumerable<BookCategory> GetAll()
        {
            return _context.BookCategories;
        }

        public void Update(BookCategory bookCategory)
        {
            throw new NotImplementedException();
        }
    }
}
