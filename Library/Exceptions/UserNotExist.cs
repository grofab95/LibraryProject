namespace Library.Exceptions
{
    public class UserNotExist : LibraryException
    {
        public UserNotExist(string name) : base($"Użytkownik: {name} nie istnieje.")
        {
        }

        public UserNotExist(int id) : base($"Użytkownik: {id} nie istnieje.")
        {
        }
    }
}
