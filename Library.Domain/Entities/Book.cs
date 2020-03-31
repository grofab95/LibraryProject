using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Library.Domain.Entities
{
    public class Book
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }

        [ForeignKey("BookCategory")]
        public int BookCategoryId { get; set; }
        public virtual BookCategory BookCategory { get; set; }
        public string ImageId { get; set; }
        public DateTime AddedDate { get; set; }
        public int Amount { get; set; }
        public int CreatorId { get; set; }
    }
}
