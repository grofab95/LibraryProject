namespace Library.Exceptions
{
    public class BookNotAvailable : LibraryException
    {
        public BookNotAvailable(string title) : base($"Książka: {title} nie jest dostępna.")
        {
        }
    }
}
