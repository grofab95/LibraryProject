using System;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public string ImageId { get; set; }
        public DateTime AddedDate { get; set; }
        public int Amount { get; set; }
        public int CreatorId { get; set; }
        public virtual ICollection<BookBorrow> BookBorrows { get; set; }
    }
}
