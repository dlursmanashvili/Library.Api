using Library.Infrastructure.HelperClass;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models;
using Library.Models.Models.Authors;
using Library.Service.IServices;

namespace Library.Service.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    private readonly IEmployeeService _employeeService;
    public AuthorService(IAuthorRepository authorRepository)
    {
        _authorRepository = authorRepository;
    }

    public async Task CreateAuthor(string Email, Guid id)
    {
        var user = await _employeeService.GetEmployeeByEmail(Email);
        ValidationHelper.UserValidation(user, Email, true);

        var author = await _authorRepository.GetByIdAsync(id);
        ValidationHelper.AuthorValidation(author);

        await _authorRepository.AddAsync(author);
    }

    public async Task<Author> GetAuthorById(Guid id)
    {
        var author = await _authorRepository.GetByIdAsync(id);
        ValidationHelper.AuthorValidation(author);
        return author;
    }

    public async Task<IEnumerable<Author>> GetAllAuthors()
    {
        return await _authorRepository.LoadAsync();
    }

    public async Task UpdateAuthor(string Email, Guid id)
    {
        var user = await _employeeService.GetEmployeeByEmail(Email);
        ValidationHelper.UserValidation(user, Email, true);

        var author = await _authorRepository.GetByIdAsync(id);
        ValidationHelper.AuthorValidation(author);

        await _authorRepository.UpdateAsync(author);
    }

    public async Task<CoommandResult> DeleteAuthor(string Email, Guid id)
    {
        var user = await _employeeService.GetEmployeeByEmail(Email);
        ValidationHelper.UserValidation(user, Email, true);

        var author = await _authorRepository.GetByIdAsync(id);
        ValidationHelper.AuthorValidation(author);

        await _authorRepository.RemoveAsync(author);
        return new CoommandResult { IsSuccess = true };
    }
}