using Library.Infrastructure.Interfaces;
using Library.Models;
using Library.Service.IServices;

namespace Library.Service.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task CreateBook(Book book)
    {
        await _bookRepository.AddAsync(book);
    }

    public async Task<Book> GetBookById(Guid id)
    {
        return await _bookRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Book>> GetAllBooks()
    {
        return await _bookRepository.LoadAsync();
    }

    public async Task UpdateBook(Book book)
    {
        await _bookRepository.UpdateAsync(book);
    }

    public async Task DeleteBook(Book book)
    {
        await _bookRepository.RemoveAsync(book);
    }
}
