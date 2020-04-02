using Library.Domain.Enums;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class AccountType
    {
        public int Id { get; set; }
        public AccountTypeName Name { get; set; }
        public virtual ICollection<User> Users { get; set; }

        public AccountType(AccountTypeName accountTypeName)
        {
            Name = accountTypeName;
        }

        protected AccountType()
        {

        }
    }
}
