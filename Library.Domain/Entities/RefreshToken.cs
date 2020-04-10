using System;

namespace Library.Domain.Entities
{
    public class RefreshToken
    {
        public int RefreshTokenId { get; set; }
        public int TokenId { get; set; }       
        public string Token { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
