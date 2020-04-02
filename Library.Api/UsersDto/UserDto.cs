using Library.Api.AccountsTypesDto;
using Library.Domain;
using Library.Domain.Entities;
using Library.Domain.Enums;

namespace Library.Api.UsersDto
{
    public class UserDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public virtual AccountTypeDto AccountType { get; set; }
    }
}

