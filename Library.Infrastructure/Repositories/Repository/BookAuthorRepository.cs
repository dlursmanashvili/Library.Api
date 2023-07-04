using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Exceptions;
using Library.Models.Models.BookAuthors;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Repository;

public class BookAuthorRepository : RepositoryBase<BookAuthor>, IBookAuthorRepository
{
    public BookAuthorRepository(ApplicationDbContext context) : base(context)
    {
    }

    public override async Task AddAsync(BookAuthor entity)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == entity.BookId) ?? throw new NotFoundException("Book with this id doesn't exists.");
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == entity.AuthorId) ?? throw new NotFoundException("Author with this id doesn't exists.");

        if (_context.BookAuthors.Any(
            x => x.BookId == entity.BookId &&
            x.AuthorId == entity.AuthorId &&
            !x.IsDeleted))
            throw new BadRequestException("record already exists");

        await _table.AddAsync(entity);
        await _context.SaveChangesAsync();
    }


    public override async Task UpdateAsync(BookAuthor entity)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == entity.BookId) ?? throw new NotFoundException("Book with this id doesn't exists.");
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == entity.AuthorId) ?? throw new NotFoundException("Author with this id doesn't exists.");

        var bookAuthor = await _context.BookAuthors.FirstOrDefaultAsync(x => x.Id == entity.Id) ?? throw new NotFoundException("Book Author with this id doesn't exists.");

        if (_context.BookAuthors.Any(
            x => x.BookId == entity.BookId &&
            x.AuthorId == entity.AuthorId &&
            x.Id != entity.Id &&
            !x.IsDeleted))
            throw new BadRequestException("record already exists");

        bookAuthor.BookId = entity.AuthorId;
        bookAuthor.BookId = entity.BookId;
        bookAuthor.IsDeleted = entity.IsDeleted;

        _table.Update(entity);
        await _context.SaveChangesAsync();
    }


    public async override Task<IEnumerable<BookAuthor>> LoadAsync()
    {
        var BookAuthors = await _context.BookAuthors.Where(x => !x.IsDeleted).ToListAsync();

        if (BookAuthors == null)
            throw new NotFoundException("BookAuthor Not Found");

        return BookAuthors;
    }
}
