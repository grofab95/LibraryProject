using Library.Domain.Adapters;
using Library.Domain.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Library.MsSqlPersistance.Dao
{
    public class AccountTypeDao : IAccountTypeDao
    {
        private LibraryContext _context;

        public AccountTypeDao(LibraryContext context)
        {
            _context = context;
        }

        public AccountType Get(int id)
        {
            return _context.AccountTypes.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<AccountType> GetAll()
        {
            return _context.AccountTypes;
        }
    }
}
