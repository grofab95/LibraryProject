using Library.Domain.Entities;
using System.Collections.Generic;

namespace Library.Domain.Adapters
{
    public interface IBookBorrowDao
    {
        IEnumerable<BookBorrow> GetAll();
        IEnumerable<BookBorrow> GetByUserId(int id);
        BookBorrow GetByBorrowId(int id);
        int CreateBorrow(BookBorrow borrow);
        void ReturnBook(int borrowId);
        void Update(BookBorrow borrow);
        void Delete(int id);
    }
}
