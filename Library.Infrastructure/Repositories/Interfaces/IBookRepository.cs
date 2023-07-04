using Library.Models.Models.Books;
using Library.Models.Models.Books.CommandModel;

namespace Library.Infrastructure.Repositories.Interfaces;

public interface IBookRepository : IRepositoryBase<Book>
{
    Task<GetBookByIdResponse> GetBookById(Guid id);
}
