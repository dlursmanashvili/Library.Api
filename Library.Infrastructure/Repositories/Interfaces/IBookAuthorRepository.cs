using Library.Models.Models.BookAuthors;
using Library.Models.Models.BookAuthors.CommandModel;

namespace Library.Infrastructure.Repositories.Interfaces;

public interface IBookAuthorRepository : IRepositoryBase<BookAuthor>
{
    Task<BookAuthorResponse> BookAuthorUpdate(UpdateBookAuthorRequest entity);
}
