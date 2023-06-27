using Library.Models;
using Library.Models.Employee;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Db;

public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
    public DbSet<Employee> Employees { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<BookAuthor>()
                .HasKey(ba => new { ba.BookId, ba.AuthorId });

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Book)
            .WithMany(b => b.BookAuthors)
            .HasForeignKey(ba => ba.BookId);

        modelBuilder.Entity<BookAuthor>()
            .HasOne(ba => ba.Author)
            .WithMany(a => a.BookAuthors)
            .HasForeignKey(ba => ba.AuthorId);


        modelBuilder.Entity<Employee>().HasData(
              new Employee
              {
                  Email = "SuperAdmin@gmail.com",
                  Id = new Guid("a1bf7271-6d45-4475-ad1f-5de6cc172dea"),
                  IsDeleted = false,
                  Password = "Password123"
              });

        base.OnModelCreating(modelBuilder);
    }
}