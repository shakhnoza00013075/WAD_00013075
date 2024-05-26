using DAL_00013075.Models_00013075;
using Microsoft.EntityFrameworkCore;

namespace DAL_00013075
{
    public class BookDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public BookDbContext(DbContextOptions<BookDbContext> options) : base(options) { }
    }
}
