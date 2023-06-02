using BookData.Models;
using BookData.Services.Models;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookData.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }


        public DbSet<Book> Book { get; set; } = null!;
        
        public DbSet<TotalPrice> TotalPrice { get; set; } = null!;

    }
}
