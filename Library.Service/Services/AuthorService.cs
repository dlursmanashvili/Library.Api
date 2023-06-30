using Library.Infrastructure.HelperClass;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models;
using Library.Models.Exceptions;
using Library.Models.Models.Authors;
using Library.Models.Models.Authors.CommandModel;
using Library.Service.IServices;

namespace Library.Service.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;

    private readonly IEmployeeService _employeeService;
    private readonly IBookAuthorRepository _bookAuthorRepository;
    public AuthorService(IAuthorRepository authorRepository, IEmployeeService employeeService, IBookAuthorRepository bookAuthorRepository)
    {
        _authorRepository = authorRepository;
        _employeeService = employeeService;
        _bookAuthorRepository = bookAuthorRepository;
    }

    public async Task<CoommandResult> CreateAuthor(CreateAuthorRequest createAuthorRequest)
    {

        ValidationHelper.GetNullParameterName(createAuthorRequest);

        var user = await _employeeService.GetEmployeeByEmail(createAuthorRequest.AdminEmail);
        if (user == null)
            throw new NotFoundException(" user not found");
        ValidationHelper.UserValidation(user, createAuthorRequest.AdminEmail, true);

        await _authorRepository.AddAsync(new Author()
        {
            Id = new Guid(),
            BirthDate = createAuthorRequest.BirthDate,
            Firstname = createAuthorRequest.Firstname,
            LastName = createAuthorRequest.LastName,
            IsDeleted = false,
        });
        return new CoommandResult();
    }
    public async Task<CoommandResult> UpdateAuthor(EditAuthorRequest editAuthorRequest)
    {
        var user = await _employeeService.GetEmployeeByEmail(editAuthorRequest.AdminEmail);
        if (user == null)
            throw new NotFoundException(" user not found");
        ValidationHelper.UserValidation(user, editAuthorRequest.AdminEmail, true);

        var author = await _authorRepository.GetByIdAsync(editAuthorRequest.AuthorID);
        ValidationHelper.AuthorValidation(author);

        await _authorRepository.UpdateAsync(new Author()
        {
            Id = editAuthorRequest.AuthorID,
            BirthDate = editAuthorRequest.BirthDate,
            Firstname = editAuthorRequest.Firstname,
            LastName = editAuthorRequest.LastName,
            IsDeleted = editAuthorRequest.IsDeleted,
            //BookAuthors = author.BookAuthors,
        });
        return new CoommandResult();
    }

    public async Task<CoommandResult> DeleteAuthor(DeleteAuthorRequest deleteAuthorRequest)
    {
        var user = await _employeeService.GetEmployeeByEmail(deleteAuthorRequest.AdminEmail);
        if (user == null)
            throw new NotFoundException(" user not found");
        ValidationHelper.UserValidation(user, deleteAuthorRequest.AdminEmail, true);

        var author = await _authorRepository.GetByIdAsync(deleteAuthorRequest.Authorid);
        ValidationHelper.AuthorValidation(author);
        var bookauthor = await _bookAuthorRepository.LoadAsync();
        if (bookauthor.Any(x => x.Id == deleteAuthorRequest.Authorid && x.IsDeleted == false))
        {
            return new CoommandResult
            {
                IsSuccess = false,
                SuccessMassage = $"Please Delete all book for  {author.Firstname} {author.LastName} author"
            };
        }

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
            throw new Exception("author not found");
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