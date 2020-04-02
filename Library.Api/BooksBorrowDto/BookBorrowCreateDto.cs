using Library.Domain.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Api.BookBorrowsDto
{
    public class BookBorrowCreateDto
    {
        [Required]
        public virtual User User { get; set; }
        [Required]
        public virtual Book Book { get; set; }
        public DateTime RentDate { get; set; }
        public bool IsBookReturned { get; set; }
        [Required]
        public int BorrowCreatorId { get; set; }
    }
}
