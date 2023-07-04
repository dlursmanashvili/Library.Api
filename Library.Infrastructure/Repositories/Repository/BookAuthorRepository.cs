using AutoMapper;
using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Exceptions;
using Library.Models.Models.BookAuthors;
using Library.Models.Models.BookAuthors.CommandModel;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Repository;

public class BookAuthorRepository : RepositoryBase<BookAuthor>, IBookAuthorRepository
{
    private readonly IMapper _mapper;

    public BookAuthorRepository(ApplicationDbContext context, 
        IMapper mapper) : base(context)
    {
        _mapper = mapper;
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

        await _dbSet.AddAsync(entity);
        await _context.SaveChangesAsync();
    }


    public async Task<BookAuthorResponse> BookAuthorUpdate(UpdateBookAuthorRequest request)
    {
        var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == request.BookId) ?? throw new NotFoundException("Book with this id doesn't exists.");
        var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == request.AuthorId) ?? throw new NotFoundException("Author with this id doesn't exists.");

        var bookAuthor = await _context.BookAuthors.FirstOrDefaultAsync(x => x.Id == request.Id) ?? throw new NotFoundException("Book Author with this id doesn't exists.");

        if (_context.BookAuthors.Any(
            x => x.BookId == request.BookId &&
            x.AuthorId == request.AuthorId &&
            x.Id != request.Id &&
            !x.IsDeleted))
            throw new BadRequestException("record already exists");

        await RemoveAsync(bookAuthor);

        var newBookAuthor = new BookAuthor()
        {
            Id = request.Id,
            AuthorId = request.AuthorId,
            BookId = request.BookId,
            IsDeleted = false
        };
        

        await AddAsync(newBookAuthor);
        return _mapper.Map<BookAuthorResponse>(newBookAuthor);

    }


    public async override Task<IEnumerable<BookAuthor>> LoadAsync()
    {
        var BookAuthors = await _context.BookAuthors.Where(x => !x.IsDeleted).ToListAsync();

        if (BookAuthors == null)
            throw new NotFoundException("BookAuthor Not Found");

        return BookAuthors;
    }
}
