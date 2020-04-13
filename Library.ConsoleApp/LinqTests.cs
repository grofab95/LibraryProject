using Library.MsSqlPersistance;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Library.ConsoleApp
{
    class LinqTests
    {
        private LibraryContext _context;

        public LinqTests(LibraryContext context)
        {
            _context = context;
        }

        public void Start()
        {
            var users = _context.Users.ToList();
            var books = _context.Books.ToList();
        }
    }
}
