using Library.Infrastructure.Db;
using Library.Infrastructure.Interfaces;
using Library.Infrastructure.Repositories;

namespace Library.Models;

public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext context) : base(context)
    {
    }
}
