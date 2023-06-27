using Library.Models;

namespace Library.Service.IServices;

public interface IBookAuthorService
{
    Task CreateBookAuthor(BookAuthor bookAuthor);
    Task UpdateBookAuthor(BookAuthor bookAuthor);
    Task DeleteBookAuthor(BookAuthor bookAuthor);
    Task<BookAuthor> GetBookAuthorById(Guid id);
    Task<IEnumerable<BookAuthor>> GetAllBookAuthor();
}
