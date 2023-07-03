using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Exceptions;
using Library.Models.Models.Authors;
using Library.Models.Models.BookAuthors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories.Repository;

public class BookAuthorRepository : RepositoryBase<BookAuthor>, IBookAuthorRepository
{
    public BookAuthorRepository(ApplicationDbContext context) : base(context)
    {
    }

    public async override Task<IEnumerable<BookAuthor>> LoadAsync()
    {
        var BookAuthors = await _context.BookAuthors.Where(x => !x.IsDeleted).ToListAsync();

        if (BookAuthors == null)
            throw new NotFoundException("BookAuthor Not Found");

        return BookAuthors;
    }
}
