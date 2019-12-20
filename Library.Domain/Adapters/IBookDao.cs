using Library.Api.Entities;
using System.Collections.Generic;

namespace Library.Api.Adapters
{
    public interface IBookDao
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        Book Create(Book book);
        void Update(Book book);
        void Delete(int id);
    }
}
