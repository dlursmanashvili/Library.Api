using Library.Infrastructure.HelperClass;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models;
using Library.Models.Models.Authors;
using Library.Models.Models.Authors.CommandModel;
using Library.Models.Models.BookAuthors;
using Library.Service.IServices;

namespace Library.Service.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    private readonly IEmployeeService _employeeService;
    public AuthorService(IAuthorRepository authorRepository, IEmployeeService employeeService)
    {
        _authorRepository = authorRepository;
        _employeeService = employeeService;
    }

    public async Task<CoommandResult> CreateAuthor(CreateAuthorRequest createAuthorRequest)
    {
        var user = await _employeeService.GetEmployeeByEmail(createAuthorRequest.AdminEmail);
        ValidationHelper.UserValidation(user, createAuthorRequest.AdminEmail, true);

        var author = await _authorRepository.GetByIdAsync(createAuthorRequest.id);
        ValidationHelper.AuthorValidation(author);

        await _authorRepository.AddAsync(author);
        return new CoommandResult();
    }
    public async Task<CoommandResult> UpdateAuthor(EditAuthorRequest editAuthorRequest)
    {
        var user = await _employeeService.GetEmployeeByEmail(editAuthorRequest.AdminEmail);
        ValidationHelper.UserValidation(user, editAuthorRequest.AdminEmail, true);

        var author = await _authorRepository.GetByIdAsync(editAuthorRequest.AuthorID);
        ValidationHelper.AuthorValidation(author);

        await _authorRepository.UpdateAsync(new Author()
        {
            Id = author.Id,
            BirthDate = editAuthorRequest.BirthDate,
            Firstname = editAuthorRequest.Firstname,
            LastName = editAuthorRequest.LastName,
            IsDeleted = editAuthorRequest.IsDeleted,
            BookAuthors = author.BookAuthors,
        });
        return new CoommandResult();
    }

    public async Task<CoommandResult> DeleteAuthor(DeleteAuthorRequest deleteAuthorRequest)
    {
        var user = await _employeeService.GetEmployeeByEmail(deleteAuthorRequest.AdminEmail);
        ValidationHelper.UserValidation(user, deleteAuthorRequest.AdminEmail, true);

        var author = await _authorRepository.GetByIdAsync(deleteAuthorRequest.id);
        ValidationHelper.AuthorValidation(author);

        await _authorRepository.RemoveAsync(author);
        return new CoommandResult { IsSuccess = true };
    }

    public async Task<GetAuthorResponse?> GetAuthorById(Guid id)
    {
        var author = await _authorRepository.GetByIdAsync(id);

        if (author != null)
        {
            return new GetAuthorResponse()
            {
                Firstname = author.Firstname,
                LastName = author.LastName,
                id = author.Id
            };
        }
        else
        {
            return null;
        }
    }

    public async Task<IEnumerable<GetAuthorResponse>?> GetAllAuthors()
    {
        var result = await _authorRepository.LoadAsync();

        if (result.Any())
        {
            return result.Select(x => new GetAuthorResponse()
            {
                Firstname = x.Firstname,
                LastName = x.LastName,
                id = x.Id
            });
        }
        return null;
    }
}