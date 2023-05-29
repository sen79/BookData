using BookData.Services.Models;

namespace BookData.Services.Interface
{
    public interface IBook : IRepository<Book>
    {
        public Task<List<Book>> GetBookListAsync();
        public Task<Book> GetBookByIdAsync(int Id);
        public Task<int> AddBookAsync(Book Book);
        public Task<int> UpdateBookAsync(Book Book);
    }
}
