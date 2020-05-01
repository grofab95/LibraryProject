using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Domain.Adapters
{
    public interface IBookAuthorDao
    {
        BookAuthor Create(BookAuthor author);
        void Delete(int authorId);
        IEnumerable<BookAuthor> GetAll();
        void Update(BookAuthor bookCategory);
    }
}
