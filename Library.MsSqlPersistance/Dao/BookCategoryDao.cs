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
            var dto = _context.BookCategories
                .Where(x => x.BookCategoryId == id)
                .Select(y => new
                {
                    Category = y,
                    CategoryBooks = y.Books.ToList()
                })
                .FirstOrDefault()
                    ?? throw new BookCategoryNotExist(id);

            if (dto.CategoryBooks.Count > 0)
                throw new CategoryHasBook(dto.Category.Name);           

            _context.BookCategories.Remove(dto.Category);
            _context.SaveChanges();
        }

        public IEnumerable<BookCategory> GetAll()
        {
            return _context.BookCategories;
        }

        public void Update(BookCategory bookCategory)
        {
            var categoryDb = _context.BookCategories
                .FirstOrDefault(x => x.BookCategoryId == bookCategory.BookCategoryId)
                ?? throw new BookCategoryNotExist(bookCategory.BookCategoryId);

            var isAlreadyExist =
                _context.BookCategories.Any(x => x.Name == bookCategory.Name);

            if (isAlreadyExist)
            {
                throw new BookCategoryExist(bookCategory.Name);
            }

            categoryDb.Name = bookCategory.Name;

            _context.SaveChanges();
        }
    }
}
