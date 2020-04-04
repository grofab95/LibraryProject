namespace Library.Exceptions
{
    public class BookBorredAlreadyTaken : LibraryException
    {
        public BookBorredAlreadyTaken(int userId, int bookId) :
            base($"Użytkownik id: {userId} już wypożyczył książkę o id: {bookId}")
        { }
    }
}
