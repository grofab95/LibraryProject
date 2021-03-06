﻿using System;
using System.Collections.Generic;

namespace Library.Domain.Entities
{
    public class BookCategory
    {
        public int BookCategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Book> Books { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
