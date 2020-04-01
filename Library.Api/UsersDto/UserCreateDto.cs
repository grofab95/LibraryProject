using Library.Domain;
using Library.Domain.Entities;
using Library.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Library.Api.UsersDto
{
    public class UserCreateDto
    {
        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Password { get; set; }

        //public AccountTypeEnum AccountTypeId { get; set; }
        public virtual AccountType AccountType { get; set; }
    }
}
