using BookData.Data;
using BookData.Services.Interface;
using Microsoft.EntityFrameworkCore;
using BookData.Services.Models;
using Microsoft.Data.SqlClient;

namespace BookData.Services.Repository
{
    public class RBook : Repository<Book>, IBook
    {
        private readonly ApplicationDbContext _dbContext;
        public RBook(ApplicationDbContext context) : base(context)
        {
            _dbContext = context;
        }

        public async Task<List<Book>> GetBookListAsync()
        {
            return await _dbContext.Book
                .FromSqlRaw<Book>("GetBookList")
                .ToListAsync();
        }

        public async Task<Book> GetBookByIdAsync(int BookId)
        {
            var param = new SqlParameter("@BookId", BookId);

            var BookDetails = await Task.Run(() => _dbContext.Book
                            .FromSqlRaw(@"exec GetBookByID @BookId", param).ToListAsync());
            Book book = BookDetails.FirstOrDefault();
            return book;
        }

        public async Task<int> AddBookAsync(Book Book)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@Publisher", Book.Publisher));
            parameter.Add(new SqlParameter("@Title", Book.Title));
            parameter.Add(new SqlParameter("@AuthorFirstName", Book.AuthorFirstName));
            parameter.Add(new SqlParameter("@AuthorLastName", Book.AuthorLastName));
            parameter.Add(new SqlParameter("@Price", Book.Price));

            var result = await Task.Run(() => _dbContext.Database
           .ExecuteSqlRawAsync(@"exec AddNewBook @Publisher, @Title, @AuthorFirstName, @AuthorLastName, @Price", parameter.ToArray()));

            return result;
        }

        public async Task<int> UpdateBookAsync(Book Book)
        {
            var parameter = new List<SqlParameter>();
            parameter.Add(new SqlParameter("@BookId", Book.BookId));
            parameter.Add(new SqlParameter("@Publisher", Book.Publisher));
            parameter.Add(new SqlParameter("@Title", Book.Title));
            parameter.Add(new SqlParameter("@AuthorFirstName", Book.AuthorFirstName));
            parameter.Add(new SqlParameter("@AuthorLastName", Book.AuthorLastName));
            parameter.Add(new SqlParameter("@Price", Book.Price));

            var result = await Task.Run(() => _dbContext.Database
            .ExecuteSqlRawAsync(@"exec UpdateBook @BookId, @Publisher, @Title, @AuthorFirstName, @AuthorLastName, @Price", parameter.ToArray()));
            return result;
        }



    }
}
