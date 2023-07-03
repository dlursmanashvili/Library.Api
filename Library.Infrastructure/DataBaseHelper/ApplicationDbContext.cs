using Library.Models.Models.Authors;
using Library.Models.Models.BookAuthors;
using Library.Models.Models.Books;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.DataBaseHelper;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasMany(x => x.BookAuthors)
            .WithOne()
            .HasForeignKey(ba => ba.BookId);

        modelBuilder.Entity<Author>()
            .HasMany(x => x.BookAuthors)
            .WithOne()
            .HasForeignKey(ba => ba.AuthorId);

        modelBuilder.Entity<BookAuthor>().HasKey(sc => new { sc.BookId, sc.AuthorId });


        base.OnModelCreating(modelBuilder);
    }

    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<BookAuthor> BookAuthors { get; set; }
}