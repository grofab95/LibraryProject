namespace Library.Exceptions
{
    public class EmptyField : LibraryException
    {
        public EmptyField(string fieldName) : base 
            ($"Pole {fieldName} jest wymagane")
        { }
    }
}
