using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Domain.Adapters
{
    public interface IBookDao
    {
        IEnumerable<Book> GetAll();
        Book GetById(int id);
        Book Create(Book book);
        void Update(Book book);
    }
}
