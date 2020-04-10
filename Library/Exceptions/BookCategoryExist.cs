namespace Library.Exceptions
{
    public class BookCategoryExist : LibraryException
    {
        public BookCategoryExist(string categoryName) : base($"Kategoria: {categoryName} już istnieje.")
        {
        }
    }
}
