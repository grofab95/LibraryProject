using Library.Api.BookCategoriesDto;
using System;

namespace Library.Api.BooksDto
{
    public class BookDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public virtual BookCategoryDto BookCategory { get; set; }
        public string ImageId { get; set; }
        public int Amount { get; set; }
        public DateTime AddedDate { get; set; }
        public int CreatorId { get; set; }
    }
}
