using Library.Api.BooksDto;
using Library.Api.UsersDto;
using System;

namespace Library.Api.BookBorrowsDto
{
    public class BookBorrowDto
    {
        public int BookBorrowId { get; set; }
        public virtual UserDto User { get; set; }
        public virtual BookDto Book { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsBookReturned { get; set; }
    }
}
