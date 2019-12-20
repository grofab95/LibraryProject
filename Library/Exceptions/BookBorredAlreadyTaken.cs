namespace Library.Exceptions
{
    public class BookBorredAlreadyTaken : LibraryException
    {
        public BookBorredAlreadyTaken(int userId, int bookId) :
            base($"User(id): {userId} is already borred this book(id): {bookId}")
        { }
    }
}
