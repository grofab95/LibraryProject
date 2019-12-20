namespace Library.Exceptions
{
    public class BookTitleAlreadyTaken : LibraryException
    {
        public BookTitleAlreadyTaken(string title) :
            base($"Book title: {title} is already taken")
        { }
    }
}
