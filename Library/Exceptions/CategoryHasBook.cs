namespace Library.Exceptions
{
    public class CategoryHasBook : LibraryException
    {
        public CategoryHasBook(string category) 
            : base($"Istnieje książka z przypisaną kategorią: {category}")
        { }
    }
}
