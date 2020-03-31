using Library.Domain.Entities;
using System;

namespace Library.Api.BooksDto
{
    public class BookUpdateDto
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public int BookCategoryId { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public int Amount { get; set; }
        public string ImageId { get; set; }
    }
}
