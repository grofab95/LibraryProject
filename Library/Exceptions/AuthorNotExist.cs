namespace Library.Exceptions
{
    public class AuthorNotExist : LibraryException
    {
        public AuthorNotExist(int id) : base($"Author o id: {id} nie istnieje.")
        {
        }
    }
}
