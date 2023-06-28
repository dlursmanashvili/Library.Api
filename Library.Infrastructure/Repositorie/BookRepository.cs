using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Interfaces;
using Library.Models;

namespace Library.Infrastructure.Repositorie;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }
}
