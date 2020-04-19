using Library.Domain.Entities;
using System;

namespace Library.Api.BooksDto
{
    public class BookUpdateDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public int AuthorId { get; set; }
        public virtual BookAuthor BookAuthor { get; set; }
        public string Description { get; set; }
        public int BookCategoryId { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public int Amount { get; set; }
        public string ImageId { get; set; }
    }
}
