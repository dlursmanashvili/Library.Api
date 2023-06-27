using Library.Infrastructure.Interfaces;
using Library.Models;

namespace Library.Service.Services;

public class BookAuthorService
{
    private readonly IBookAuthorRepository _bookAuthorRepository;

    public BookAuthorService(IBookAuthorRepository bookAuthorRepository)
    {
        _bookAuthorRepository = bookAuthorRepository;
    }

    public async Task CreateBookAuthor(BookAuthor bookAuthor)
    {
        await _bookAuthorRepository.AddAsync(bookAuthor);
    }

    public async Task<BookAuthor> GetBookAuthorById(Guid id)
    {
        return await _bookAuthorRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<BookAuthor>> GetAllBookAuthor()
    {
        return await _bookAuthorRepository.LoadAsync();
    }

    public async Task UpdateBookAuthor(BookAuthor bookAuthor)
    {
        await _bookAuthorRepository.UpdateAsync(bookAuthor);
    }

    public async Task DeleteBookAuthor(BookAuthor bookAuthor)
    {
        await _bookAuthorRepository.RemoveAsync(bookAuthor);
    }

}
