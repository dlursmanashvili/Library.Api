using Library.Models;
using Library.Models.Models.Books.CommandModel;

namespace Library.Service.IServices;

public interface IBookService
{
    Task<BookResponse> GetBookById(Guid id);
    Task<IEnumerable<BookResponse>> GetAllBooks();
    Task<BookResponse> CreateBook(CreateBookRequest createBookModel);
    Task<BookResponse> UpdateBook(UpdateBookRequest updateBookRequest);
    Task<bool> DeleteBook(DeleteBookRequest deleteBookRequest);
    Task<CoommandResult> EditBookStatus(UpdateBookStatusRequest updateBookStatusRequest);
    Task<CoommandResult> GetBookStatus(Guid getBookStatusResponse);
}
