using Library.Api.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Api.BookBorrowsDto
{
    public class BookBorrowCreateDto
    {
        [Required]
        public int UserId { get; set; }
        public virtual User User { get; set; }
        [Required]
        public int BookId { get; set; }
        public virtual Book Book { get; set; }        
        public DateTime BorrowDate { get; set; }
        public bool IsBookReturned { get; set; }
    }
}
