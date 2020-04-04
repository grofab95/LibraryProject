namespace Library.Exceptions
{
    public class InvalidInput : LibraryException
    {
        public InvalidInput(string input) : base($"{input} jest niepoprawny")
        { }

        public InvalidInput(string input, string input2) : base($"Niepoprawne pola: {input}, {input2}")
        { }
    }
}
