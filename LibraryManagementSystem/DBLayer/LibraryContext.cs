using LibraryManagementSystem.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace LibraryManagementSystem.DBLayer
{
    public class ILibraryContext : DbContext
    {
        public ILibraryContext(DbContextOptions<ILibraryContext> options) : base(options) { }

        public DbSet<Book> Books => Set<Book>();
        public DbSet<Member> Members => Set<Member>();
        public DbSet<BorrowRecord> BorrowRecords => Set<BorrowRecord>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Book>().HasData(

                new Book
                {
                    BookId = 2,
                    Title = "The Alchemist",
                    Author = "Paulo Coelho",
                    ISBN = "9780062315007",
                    Stock = 3
                },
                new Book
                {
                    BookId = 3,
                    Title = "To Kill a Mockingbird",
                    Author = "Harper Lee",
                    ISBN = "9780061120084",
                    Stock = 4
                },
                new Book
                {
                    BookId = 4,
                    Title = "The Catcher in the Rye",
                    Author = "J.D. Salinger",
                    ISBN = "9780316769488",
                    Stock = 4
                },
                new Book
                {
                    BookId = 5,
                    Title = "Sapiens: A Brief History of Humankind",
                    Author = "Yuval Noah Harari",
                    ISBN = "9780062316097",
                    Stock = 6
                },
                new Book
                {
                    BookId = 6,
                    Title = "The Great Gatsby",
                    Author = "F. Scott Fitzgerald",
                    ISBN = "9780743273565",
                    Stock = 3
                },
                new Book
                {
                    BookId = 7,
                    Title = "Educated",
                    Author = "Tara Westover",
                    ISBN = "9780399590504",
                    Stock = 5
                },
                new Book
                {
                    BookId = 8,
                    Title = "Thinking, Fast and Slow",
                    Author = "Daniel Kahneman",
                    ISBN = "9780374533557",
                    Stock = 4
                },
                new Book
                {
                    BookId = 9,
                    Title = "The Power of Now",
                    Author = "Eckhart Tolle",
                    ISBN = "9781577314806",
                    Stock = 2
                },
                new Book
                {
                    BookId = 10,
                    Title = "The Hobbit",
                    Author = "J.R.R. Tolkien",
                    ISBN = "9780547928227",
                    Stock = 7
                }

            );
        }

    }
}
