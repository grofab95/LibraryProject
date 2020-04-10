namespace Library.Exceptions
{
    public class BookNotExist : LibraryException
    {
        public BookNotExist(string title) : base($"Książka: {title} nie istnieje.")
        {
        }

        public BookNotExist(int id) : base($"Książka: {id} nie istnieje.")
        {
        }
    }
}
