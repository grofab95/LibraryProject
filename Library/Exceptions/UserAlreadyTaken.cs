namespace Library.Exceptions
{
    public class UserAlreadyTaken : LibraryException
    {
        public UserAlreadyTaken(string fistName, string lastName) : 
            base($"User {fistName} {lastName}")
        { }
    }
}
