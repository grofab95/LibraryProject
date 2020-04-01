namespace Library.Exceptions.AuthExceptions
{
    public class WrongPassword : LibraryException
    {
        public WrongPassword()
            : base("Podane hasło jest niewłaściwe.")
        {
        }
    }
}
