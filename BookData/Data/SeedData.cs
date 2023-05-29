using BookData.Services.Models;

namespace BookData.Data
{
    public class SeedData
    {
        public IEnumerable<Book> GetBookList()
        {
            return new List<Book>
            {
                new Book {  Publisher = "Test Publisher 1", Title = "Tittle 1", AuthorFirstName = "FName 1", AuthorLastName = "LName 1", Price = 100 },
                new Book {  Publisher = "Test Publisher 2", Title = "Tittle 2", AuthorFirstName = "FName 2", AuthorLastName = "LName 1", Price = 200 },
                new Book {  Publisher = "Test Publisher 3", Title = "Tittle 3", AuthorFirstName = "FName 3", AuthorLastName = "LName 1", Price = 300 },
                new Book {  Publisher = "Test Publisher 4", Title = "Tittle 4", AuthorFirstName = "FName 4", AuthorLastName = "LName 1", Price = 400 },
                new Book {  Publisher = "Test Publisher 5", Title = "Tittle 5", AuthorFirstName = "FName 5", AuthorLastName = "LName 1", Price = 500 },
            };
        }
    }
}
