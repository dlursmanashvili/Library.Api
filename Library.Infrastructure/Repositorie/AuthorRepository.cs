using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Interfaces;
using Library.Models;

namespace Library.Infrastructure.Repositorie;

public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext context) : base(context)
    {
    }
}
