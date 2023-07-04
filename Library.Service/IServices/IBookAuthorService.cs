using Library.Models.Models.BookAuthors.CommandModel;

namespace Library.Service.IServices;

public interface IBookAuthorService
{
    Task<BookAuthorResponse> CreateBookAuthor(CreateBookAuthorRequest createBookAuthorRequest);
    Task<BookAuthorResponse> UpdateBookAuthor(UpdateBookAuthorRequest editBookAuthorRequest);
    Task<bool> DeleteBookAuthor(DeleteBookAuthorRequest deleteBookAuthorRequest);
    Task<BookAuthorResponse> GetBookAuthorById(Guid idBookAutrhorID);
    Task<IEnumerable<BookAuthorResponse>?> GetAllBookAuthor();
}
