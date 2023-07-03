using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Exceptions;
using Library.Models.Models.BookAuthors;
using Library.Models.Models.Books;
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
}
