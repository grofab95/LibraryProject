namespace Library.Exceptions
{
    public class InvalidInput : LibraryException
    {
        public InvalidInput(string input) : base($"{input} is incorrext")
        { }

        public InvalidInput(string input, string input2) : base($"Invalids inputs: {input}, {input2}")
        { }
    }
}
