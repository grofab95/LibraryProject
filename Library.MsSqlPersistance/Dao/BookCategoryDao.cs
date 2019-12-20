using Library.Api.Adapters;
using Library.Api.Entities;
using Library.Exceptions;
using System.Collections.Generic;
using System.Linq;

namespace Library.MsSqlPersistance.Dao
{
    public class BookCategoryDao : IBookCategoryDao
    {
        private DataContext _context;

        public BookCategoryDao(DataContext context)
        {
            _context = context;
        }

        public BookCategory Create(BookCategory bookCategory)
        {
            if (string.IsNullOrWhiteSpace(bookCategory.Name))
            {
                throw new LibraryException("Category name is required");
            }

            if (_context.BookCategories.Any(x => x.Name == bookCategory.Name))
            {
                throw new LibraryException($"Category name: {bookCategory.Name} is already taken");
            }

            _context.BookCategories.Add(bookCategory);
            _context.SaveChanges();

            return bookCategory;
        }

        public void Delete(int id)
        {
            var bookCategory = _context.BookCategories.Find(id);
            if (bookCategory != null)
            {
                _context.Remove(bookCategory);
                _context.SaveChanges();
            }
        }

        public IEnumerable<BookCategory> GetAll()
        {
            return _context.BookCategories;
        }

        public BookCategory GetById(int id)
        {
            return _context.BookCategories.Find(id);
        }

        public void Update(BookCategory bookCategory)
        {
            var category = _context.BookCategories.Find(bookCategory.Id);

            if (category == null)
            {
                throw new LibraryException("Book category not found");
            }
            
            if (!string.IsNullOrWhiteSpace(bookCategory.Name) && (bookCategory.Name == category.Name))
            {
                if (_context.BookCategories.Any(x => x.Name == bookCategory.Name))
                {
                    throw new LibraryException($"Book category name: {bookCategory.Name} is already taken");
                }
                category.Name = bookCategory.Name;
            }
            _context.BookCategories.Update(category);
            _context.SaveChanges();
        }
    }
}
