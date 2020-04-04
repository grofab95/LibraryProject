namespace Library.Exceptions
{
    public class BookTitleAlreadyTaken : LibraryException
    {
        public BookTitleAlreadyTaken(string title) :
            base($"Książka: {title} już istnieje")
        { }
    }
}
