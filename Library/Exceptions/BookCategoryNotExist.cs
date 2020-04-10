namespace Library.Exceptions
{
    public class BookCategoryNotExist : LibraryException
    {
        public BookCategoryNotExist(int id) : base($"Kategoria o id: {id} nie istnieje.")
        {
        }
    }
}
