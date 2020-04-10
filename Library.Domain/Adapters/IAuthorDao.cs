using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Domain.Adapters
{
    public interface IBookAuthorDao
    {
        int Create(BookAuthor author);
        void Delete(int id);
        IEnumerable<BookAuthor> GetAll();
        void Update(BookAuthor bookCategory);
    }
}
