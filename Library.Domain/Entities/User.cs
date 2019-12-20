using Library.Api.Enums;

namespace Library.Api.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public AccountTypeEnum AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }
    }
}
