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

        public BookAuthor Create(BookAuthor author)
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
            return author;
        }

        public void Delete(int authorId)
        {
            var dto = _context.BookAuthors
                .Where(x => x.BookAuthorId == authorId)
                .Select(y => new
                {
                    Author = y,
                    AthorBooks = y.Books.ToList()
                })
                .FirstOrDefault()
                    ?? throw new AuthorNotExist(authorId);

            var hasAuthorBooks = dto.AthorBooks.Count > 0;

            if (hasAuthorBooks)
                throw new AuthorHasBooks(dto.Author.FullName);

            _context.BookAuthors.Remove(dto.Author);
            _context.SaveChanges();
        }

        public IEnumerable<BookAuthor> GetAll()
        {
            return _context.BookAuthors;
        }

        public void Update(BookAuthor bookAuthor)
        {
            var authorDb = _context.BookAuthors
                .FirstOrDefault(x => x.BookAuthorId == bookAuthor.BookAuthorId)
                ?? throw new AuthorNotExist(bookAuthor.BookAuthorId);

            var isAlreadyExist = 
                _context.BookAuthors.Any(x => x.Name == bookAuthor.Name && x.Surname == bookAuthor.Surname);

            if (isAlreadyExist)
            {
                throw new AuthorExist();
            }

            authorDb.Name = bookAuthor.Name;
            authorDb.Surname = bookAuthor.Surname;

            _context.SaveChanges();
        }
    }
}
