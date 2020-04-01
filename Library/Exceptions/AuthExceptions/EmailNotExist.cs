namespace Library.Exceptions.AuthExceptions
{
    public class EmailNotExist : LibraryException
    {
        public EmailNotExist(string email) 
            : base($"Podany e-mail: {email} nie istnieje.")
        {
        }
    }
}
