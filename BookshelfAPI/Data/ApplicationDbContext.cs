using Microsoft.EntityFrameworkCore;
using BookshelfAPI.Models;

namespace BookshelfAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ReadingLog> ReadingLogs { get; set; }
    }
}
