using Library.Models;
using Library.Models.Models.Books;
using Library.Models.Models.Books.CommandModel;

namespace Library.Service.IServices;

public interface IBookService
{
    Task<CoommandResult> CreateBook(CreateBookRequest createBookModel);
    Task<CoommandResult> UpdateBook(UpdateBookRequest updateBookRequest);
    Task<CoommandResult> DeleteBook(DeleteBookRequest deleteBookRequest);
    Task<GetBookResponse> GetBookById(Guid id);
    Task<IEnumerable<GetBookResponse>> GetAllBooks();
}
