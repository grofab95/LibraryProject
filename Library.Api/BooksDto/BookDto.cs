using Library.Api.BookAuthorsDto;
using Library.Api.BookCategoriesDto;

namespace Library.Api.BooksDto
{
    public class BookDto
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public BookAuthorDto BookAuthor { get; set; }
        public string Description { get; set; }
        public BookCategoryDto BookCategory { get; set; }
        public string ImageId { get; set; }
        public int Amount { get; set; }
        public int CreatorId { get; set; }
    }
}
