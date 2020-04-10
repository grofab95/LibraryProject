namespace Library.Domain.Entities
{
    public class UserWithToken : User
    {
        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }

        public UserWithToken(User user)
        {
            this.Email = user.Email;
            this.UserId = user.UserId;
            this.Name = user.Name;
            this.Surname = user.Surname;
            this.AccountType = user.AccountType;
        }
    }
}
