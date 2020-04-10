using Library.Domain;
using Library.Domain.Entities;
using Library.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Library.Api.UsersDto
{
    public class UserCreateDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Surname { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        public virtual AccountType AccountType { get; set; }
    }
}
