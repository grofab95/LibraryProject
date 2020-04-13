using Library.Api.AccountsTypesDto;

namespace Library.Api.UsersDto
{
    public class UserWithTokenDto
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public virtual AccountTypeDto AccountType { get; set; }
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
    }
}
