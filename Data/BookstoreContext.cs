using dotnet.Models;
using Microsoft.EntityFrameworkCore;

namespace dotnet.Data
{
    public class BookstoreContext : DbContext
    {
        public BookstoreContext(DbContextOptions<BookstoreContext> options)
            : base(options)
        {
        }

        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Seed Authors
            modelBuilder.Entity<Author>().HasData(
                new Author { Id = 1, Name = "J.R.R. Tolkien" },
                new Author { Id = 2, Name = "George Orwell" }
            );

            // Seed Books
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "The Hobbit", AuthorId = 1 },
                new Book { Id = 2, Title = "The Lord of the Rings", AuthorId = 1 },
                new Book { Id = 3, Title = "1984", AuthorId = 2 },
                new Book { Id = 4, Title = "Animal Farm", AuthorId = 2 }
            );
        }
    }
}
