using Library.Domain.Enums;
using System;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class AccountType
    {
        public int AccountTypeId { get; set; }
        public AccountTypeName Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public DateTime CreatedDate { get; set; }

        public AccountType(AccountTypeName accountTypeName)
        {
            Name = accountTypeName;
        }

        public AccountType()
        {

        }
    }
}
