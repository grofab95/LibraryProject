using System;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class BookAuthor
    {
        public int BookAuthorId { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
