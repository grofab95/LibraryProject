using System.ComponentModel.DataAnnotations;

namespace Library.Api.BookCategoriesDto
{
    public class BookCategoryRegisterDto
    {
        [Required]
        public string Name { get; set; }
    }
}
