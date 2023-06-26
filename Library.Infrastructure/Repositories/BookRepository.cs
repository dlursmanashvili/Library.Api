using Library.Infrastructure.Db;
using Library.Infrastructure.Interfaces;
using Library.Models;

namespace Library.Infrastructure.Repositories;

public class BookRepository : RepositoryBase<Book>, IBookRepository
{
    public BookRepository(ApplicationDbContext context) : base(context)
    {
    }
}
