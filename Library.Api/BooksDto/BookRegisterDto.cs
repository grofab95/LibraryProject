using Library.Api.Entities;
using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Api.BooksDto
{
    public class BookRegisterDto
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public int BookCategoryId { get; set; }
        public virtual BookCategory BookCategory { get; set; }

        [Required]
        public string ImageId { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        [Required]
        public int CreatorId { get; set; }
        public int Amount { get; set; }
    }
}
