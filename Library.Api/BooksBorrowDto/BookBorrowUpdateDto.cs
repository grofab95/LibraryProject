using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Api.BookBorrowsDto
{
    public class BookBorrowUpdateDto
    {
        [Required]
        public int BookBorrowId { get; set; }
        [Required]
        public bool IsBookReturned { get; set; }
        public DateTime ReturnDate { get; set; }
    }
}
