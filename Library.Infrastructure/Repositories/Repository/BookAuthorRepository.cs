using Library.Infrastructure.DataBaseHelper;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Models.BookAuthors;
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
}
