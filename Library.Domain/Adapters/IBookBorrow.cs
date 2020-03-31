using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Api.Adapters
{
    public interface IBookBorrow
    {
        IEnumerable<BookBorrow> GetAll();
        BookBorrow GetById(int id);
        BookBorrow Create(BookBorrow book);
        void Update(BookBorrow book);
        void Delete(int id);
    }
}
