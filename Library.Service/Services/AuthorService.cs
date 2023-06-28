using Library.Infrastructure.Interfaces;
using Library.Models;
using Library.Service.IServices;

namespace Library.Service.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task CreateAuthor(Author author)
    {
        await _authorRepository.AddAsync(author);
    }

    public async Task<Author> GetAuthorById(Guid id)
    {
        return await _authorRepository.GetByIdAsync(id);
    }

    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        return await _authorRepository.LoadAsync();
    }

    public async Task UpdateAuthor(Author author)
    {
        await _authorRepository.UpdateAsync(author);
    }

    public async Task DeleteAuthor(Author author)
    {
        await _authorRepository.RemoveAsync(author);
    }
}