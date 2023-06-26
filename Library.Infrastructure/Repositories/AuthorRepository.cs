using Library.Infrastructure.Db;
using Library.Infrastructure.Interfaces;
using Library.Infrastructure.Repositories;

namespace Library.Models;

public class AuthorREpository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorREpository(ApplicationDbContext context) : base(context)
    {
    }
}
