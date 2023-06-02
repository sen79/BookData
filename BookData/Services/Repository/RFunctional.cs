using BookData.Data;
using BookData.Services.Interface;
using Microsoft.Extensions.Options;

namespace BookData.Services.Repository
{
    public class RFunctional : IFunctional
    {
        private readonly ApplicationDbContext _context;

        public RFunctional(
           ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task InitAppData()
        {
            SeedData _SeedData = new SeedData();

            var _GetBookList = _SeedData.GetBookList();
            foreach (var item in _GetBookList)
            {
                await _context.Book.AddAsync(item);
                await _context.SaveChangesAsync();
            }
        }


    }
}
