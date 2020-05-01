namespace Library.Exceptions
{
    public class AuthorHasBooks : LibraryException
    {
        public AuthorHasBooks(string author) : base($"Istnieją książki które posiadają tego autora: {author}.")
        { }
    }
}

