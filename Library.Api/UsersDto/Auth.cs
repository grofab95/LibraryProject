using System;

namespace Library.Api.UsersDto
{
    public class Auth
    {
        public string Token { get; set; }
        public DateTime? ExpirationIn { get; set; }
    }
}
