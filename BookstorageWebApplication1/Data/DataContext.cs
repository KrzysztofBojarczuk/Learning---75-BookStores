using BookstorageWebApplication1.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstorageWebApplication1.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Bookstore> Bookstores { get; set; }
    }
}
