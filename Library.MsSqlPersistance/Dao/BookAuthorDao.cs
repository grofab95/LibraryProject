using Library.Domain.Adapters;
using Library.Domain.Entities;
using Library.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.MsSqlPersistance.Dao
{
    public class BookAuthorDao : IBookAuthorDao
    {
        private LibraryContext _context;

        public BookAuthorDao(LibraryContext context)
        {
            _context = context;
        }

        public int Create(BookAuthor author)
        {
            if (string.IsNullOrWhiteSpace(author.Name))
            {
                throw new EmptyField("author name");
            }

            if (string.IsNullOrWhiteSpace(author.Surname))
            {
                throw new EmptyField("author surname");
            }

            if (_context.BookAuthors
                .Any(x => x.Name == author.Name && x.Surname == author.Surname))
            {
                throw new AuthorExist($"{author.Name} {author.Surname}");
            }

            _context.BookAuthors.Add(author);
            _context.SaveChanges();
            return author.BookAuthorId;
        }

        public void Delete(int id)
        {
            var author = _context.BookAuthors
                .FirstOrDefault(x => x.BookAuthorId == id)
                    ?? throw new AuthorNotExist(id);

            _context.BookAuthors.Remove(author);
            _context.SaveChanges();
        }

        public IEnumerable<BookAuthor> GetAll()
        {
            return _context.BookAuthors;
        }

        public void Update(BookAuthor bookCategory)
        {
            throw new NotImplementedException();
        }
    }
}
