using Library.Domain.Entities;
using System;

namespace Library.Api.BookBorrowsDto
{
    public class BookBorrowDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTime BorrowDate { get; set; }
        public bool IsBookReturned { get; set; }
    }
}
