using BookData.Data;
using BookData.Services.Interface;

namespace BookData.Data
{
    public static class DbInitializer
    {
        public static async Task Initialize(ApplicationDbContext context, IFunctional functional)
        {
            context.Database.EnsureCreated();
            if (context.Book.Any())
            {
                return;
            }
            else
            {
                await functional.InitAppData();
            }
        }
    }
}
