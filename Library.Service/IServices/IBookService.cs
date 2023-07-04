using Library.Models;
using Library.Models.Models.Books.CommandModel;

namespace Library.Service.IServices;

public interface IBookService
{
    Task<GetBookByIdResponse> GetBookById(Guid id);
    Task<IEnumerable<GetAllBooksResponse>> GetAllBooks();
    Task<BookResponse> CreateBook(CreateBookRequest createBookModel);
    Task<BookResponse> UpdateBook(UpdateBookRequest updateBookRequest);
    Task<bool> DeleteBook(DeleteBookRequest deleteBookRequest);
    Task<CoommandResult> EditBookStatus(UpdateBookStatusRequest updateBookStatusRequest);
    Task<CoommandResult> GetBookStatus(Guid getBookStatusResponse);
    Task<IEnumerable<BookResponse>?> SearchBooks(string Title);
}
