using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Domain.Adapters
{
    public interface IBookBorrowDao
    {
        IEnumerable<BookBorrow> GetAll();
        IEnumerable<BookBorrow> GetByUserEmail(string email);
        BookBorrow GetById(int id);
        int Create(BookBorrow bookBorrow, int userId, int bookId);
        void Update(BookBorrow book);
        void Delete(int id);
    }
}
