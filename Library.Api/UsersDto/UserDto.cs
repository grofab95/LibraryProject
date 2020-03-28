using Library.Api.Enums;

namespace Library.Api.UsersDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public AccountTypeEnum AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }
        public virtual Auth Auth { get; set; }
    }
}

