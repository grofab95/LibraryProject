using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Api.BookBorrowsDto
{
    public class BookBorrowCreateDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public int BorrowCreatorId { get; set; }
    }
}
