namespace Library.Exceptions
{
    public class EmptyField : LibraryException
    {
        public EmptyField(string fieldName) : base 
            ($"The {fieldName} is required")
        { }
    }
}
