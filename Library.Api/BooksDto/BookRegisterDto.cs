using Library.Domain.Entities;
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

        public string ImageId { get; set; }

        [Required]
        public DateTime AddedDate { get; set; }

        [Required]
        public int CreatorId { get; set; }
        public int Amount { get; set; }
    }
}
