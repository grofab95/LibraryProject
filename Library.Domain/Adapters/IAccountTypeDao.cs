using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Domain.Adapters
{
    public interface IAccountTypeDao
    {
        IEnumerable<AccountType> GetAll();
        AccountType Get(int id);
    }
}
