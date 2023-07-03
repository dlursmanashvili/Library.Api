using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Exceptions;
using Library.Models.Models.Authors;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastructure.Repositories.Repository;

public class AuthorRepository : RepositoryBase<Author>, IAuthorRepository
{
    public AuthorRepository(ApplicationDbContext context) : base(context)
    {
    }
    
    public async override Task<IEnumerable<Author>> LoadAsync() { 
        var authors = await _context.Authors.Where(x => !x.IsDeleted).ToListAsync();

        if (authors == null)
            throw new NotFoundException("Authors Not Found");
        
        return authors;
    }
}
