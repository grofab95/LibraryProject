using System;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class Book
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageId { get; set; }
        public int Amount { get; set; }
        public int BookCategoryId { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public int BookAuthorId { get; set; }
        public virtual BookAuthor BookAuthor { get; set; }
        public virtual ICollection<BookBorrow> BookBorrows { get; set; }
        public DateTime CreatedDate { get; set; }
        public int CreatorId { get; set; }
    }
}
