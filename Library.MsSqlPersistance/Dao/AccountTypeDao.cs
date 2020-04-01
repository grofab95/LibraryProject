using Library.Domain.Adapters;
using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.MsSqlPersistance.Dao
{
    public class AccountTypeDao : IAccountTypeDao
    {
        public AccountType Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AccountType> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
