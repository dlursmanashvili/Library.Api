using Library.Models;
using Library.Models.Models.BookAuthors;
using Library.Models.Models.BookAuthors.CommandModel;

namespace Library.Service.IServices;

public interface IBookAuthorService
{
    Task<BookAuthorResponse> CreateBookAuthor(CreateBookAuthorRequest createBookAuthorRequest);
    Task<BookAuthorResponse> UpdateBookAuthor(EditBookAuthorRequest editBookAuthorRequest);
    Task<bool> DeleteBookAuthor(DeleteBookAuthorRequest deleteBookAuthorRequest);
    Task<BookAuthorResponse> GetBookAuthorById(Guid idBookAutrhorID);
    Task<IEnumerable<BookAuthorResponse>?> GetAllBookAuthor();
}
