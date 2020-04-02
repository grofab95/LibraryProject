using Library.Domain.Enums;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class BookCategory
    {
        public int Id { get; set; }
        public BookCategoryName Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }

        protected BookCategory() { }

        public BookCategory(BookCategoryName bookCategoryNames)
        {
            Name = bookCategoryNames;
        }
    }
}
