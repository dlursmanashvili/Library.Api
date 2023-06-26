using Library.Infrastructure.Db;
using Library.Infrastructure.Interfaces;
using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastructure.Repositories;

public class BookAuthorRepository : RepositoryBase<BookAuthor>, IBookAuthorRepository
{
    public BookAuthorRepository(ApplicationDbContext context) : base(context)
    {
    }
}
