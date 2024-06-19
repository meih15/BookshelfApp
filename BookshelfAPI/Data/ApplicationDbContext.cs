using Microsoft.EntityFrameworkCore;
using BookshelfAPI.Models;

namespace BookshelfAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ReadingLog> ReadingLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Define the relationship between Author and Book
            modelBuilder.Entity<Author>()
                .HasMany(a => a.Books)
                .WithOne(b => b.Author)
                .HasForeignKey(b => b.AuthorId)
                .OnDelete(DeleteBehavior.Cascade);

            // Define the relationship between Book and Review
            modelBuilder.Entity<Book>()
                .HasMany(b => b.Reviews)
                .WithOne(r => r.Book)
                .HasForeignKey(r => r.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Define the relationship between Book and ReadingLog
            modelBuilder.Entity<Book>()
                .HasMany(b => b.ReadingLogs)
                .WithOne(rl => rl.Book)
                .HasForeignKey(rl => rl.BookId)
                .OnDelete(DeleteBehavior.Cascade);

            // Define the relationship between User and Review (if applicable)
            modelBuilder.Entity<User>()
                .HasMany(u => u.Reviews)
                .WithOne(r => r.User)
                .HasForeignKey(r => r.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            // Define the relationship between User and ReadingLog (if applicable)
            modelBuilder.Entity<User>()
                .HasMany(u => u.ReadingLogs)
                .WithOne(rl => rl.User)
                .HasForeignKey(rl => rl.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
