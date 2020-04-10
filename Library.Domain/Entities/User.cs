using System;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class User
    {
        public User()
        {
            RefreshTokens = new HashSet<RefreshToken>();
        }

        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public int AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual ICollection<RefreshToken> RefreshTokens { get; set; }
        public virtual ICollection<BookBorrow> BookBorrows { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
