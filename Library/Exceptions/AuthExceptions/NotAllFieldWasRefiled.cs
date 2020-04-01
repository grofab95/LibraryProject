namespace Library.Exceptions.AuthExceptions
{
    public class NotAllFieldWasRefiled : LibraryException
    {
        public NotAllFieldWasRefiled() 
            : base("Nie wszystkie pola zostały uzupełnione.")
        {
        }
    }
}
