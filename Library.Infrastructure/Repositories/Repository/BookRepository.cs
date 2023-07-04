using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Exceptions;
using Library.Models.Models.Authors.CommandModel;
using Library.Models.Models.Books;
using Library.Models.Models.Books.CommandModel;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Repository;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }
    public async override Task<IEnumerable<Book>> LoadAsync()
    {
        var Books = await _context.Books.Where(x => !x.IsDeleted).ToListAsync();

        if (Books == null)
            throw new NotFoundException("Book Not Found");

        return Books;
    }

    public async Task<GetBookByIdResponse> GetBookById(Guid id)
    {
        var book = (from b in _context.Books

                    where b.Id == id && !b.IsDeleted
                    select new GetBookByIdResponse
                    {
                        Id = b.Id,
                        Title = b.Title,
                        Image = b.Image,
                        Rating = b.Rating,
                        InLibrary = b.InLibrary,
                        Description = b.Description,
                        PublicationDate = b.PublicationDate,
                        FilePath = b.FilePath,
                        Authors = (from ba in _context.BookAuthors
                                 join a in _context.Authors on ba.AuthorId equals a.Id
                                 where ba.BookId == b.Id
                                 select new AuthorResponse
                                 {
                                     Id = a.Id,
                                     Firstname = a.Firstname,
                                     LastName = a.LastName
                                 }).ToList()
                    }).FirstOrDefault();

        if (book == null)
            throw new NotFoundException("Book not found");

        return book;
    }
}


