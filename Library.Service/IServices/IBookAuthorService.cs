using Library.Models;
using Library.Models.Models.BookAuthors;
using Library.Models.Models.BookAuthors.CommandModel;

namespace Library.Service.IServices;

public interface IBookAuthorService
{
    Task<CoommandResult> CreateBookAuthor(CreateBookAuthorRequest createBookAuthorRequest);
    Task<CoommandResult> UpdateBookAuthor(EditBookAuthorRequest editBookAuthorRequest);
    Task<CoommandResult> DeleteBookAuthor(DeleteBookAuthorRequest deleteBookAuthorRequest);
    Task<GetBookAuthorResponse> GetBookAuthorById(Guid idBookAutrhorID);
    Task<IEnumerable<GetBookAuthorResponse>?> GetAllBookAuthor();
}
