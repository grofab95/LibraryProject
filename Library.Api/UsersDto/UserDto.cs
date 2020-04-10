using Library.Api.AccountsTypesDto;

namespace Library.Api.UsersDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public virtual AccountTypeDto AccountType { get; set; }
    }
}

