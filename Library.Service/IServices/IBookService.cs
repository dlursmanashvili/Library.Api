using Library.Models;

namespace Library.Service.IServices;

public interface IBookService
{
    Task CreateBook(Book book);
    Task UpdateBook(Book book);
    Task DeleteBook(Book book);
    Task<Book> GetBookById(Guid id);
    Task<IEnumerable<Book>> GetAllBooks();
}
