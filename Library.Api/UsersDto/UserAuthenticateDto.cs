using System.ComponentModel.DataAnnotations;

namespace Library.Api.UsersDto
{
    public class UserAuthenticateDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
