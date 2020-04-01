using Library.Domain.Entities;
using Library.MsSqlPersistance;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Library.ConsoleApp
{
    class Program
    {
        static void Main()
        {
            var context = new LibraryContext();

            var roles = new List<AccountType>
            {
                new AccountType{ Name = "Admin" },
                new AccountType{ Name = "Librarian" },
                new AccountType{ Name = "User" },
            };

            context.AccountTypes.AddRange(roles);

            //ontext.SaveChanges();
        }
    }
}
