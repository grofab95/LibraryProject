using Library.Api.Entities;
using System.Collections.Generic;

namespace Library.Api.Adapters
{
    public interface IBookCategoryDao
    {
        IEnumerable<BookCategory> GetAll();
        BookCategory GetById(int id);
        BookCategory Create(BookCategory bookCategory);
        void Update(BookCategory bookCategory);
        void Delete(int id);
    }
}
