﻿using System;
namespace Library.Domain.Entities
{
    public class BookBorrow
    {
        public int BookBorrowId { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
        public int BookId { get; set; }
        public virtual Book Book { get; set; }
        public DateTime RentDate { get; set; }
        public DateTime ReturnDate { get; set; }
        public bool IsBookReturned { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
