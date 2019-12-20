using System.ComponentModel.DataAnnotations;

namespace Library.Api.BookBorrowsDto
{
    public class BookBorrowUpdateDto
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public bool IsBookReturned { get; set; }
    }
}
