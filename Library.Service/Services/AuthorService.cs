using AutoMapper;
using Library.Infrastructure.HelperClass;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Exceptions;
using Library.Models.Models.Authors;
using Library.Models.Models.Authors.CommandModel;
using Library.Service.IServices;

namespace Library.Service.Services;

public class AuthorService : IAuthorService
{
    private readonly IAuthorRepository _authorRepository;
    private readonly IBookAuthorRepository _bookAuthorRepository;
    private readonly IMapper _mapper;
    public AuthorService(
        IAuthorRepository authorRepository,
        IBookAuthorRepository bookAuthorRepository,
        IMapper mapper)
    {
        _authorRepository = authorRepository;
        _bookAuthorRepository = bookAuthorRepository;
        _mapper = mapper;
    }

    public async Task<AuthorResponse> CreateAuthor(CreateAuthorRequest createAuthorRequest)
    {
        var author = new Author()
        {
            Id = Guid.NewGuid(),
            BirthDate = createAuthorRequest.BirthDate,
            Firstname = createAuthorRequest.Firstname,
            LastName = createAuthorRequest.LastName,
            IsDeleted = false,
        };
        await _authorRepository.AddAsync(author);
        return _mapper.Map<AuthorResponse>(author);
    }
    public async Task<AuthorResponse> UpdateAuthor(EditAuthorRequest editAuthorRequest)
    {
        var author = await _authorRepository.GetByIdAsync(editAuthorRequest.AuthorID);
        ValidationHelper.AuthorValidation(author);

        author.BirthDate = editAuthorRequest.BirthDate;
        author.Firstname = editAuthorRequest.Firstname;
        author.LastName = editAuthorRequest.LastName;
        author.IsDeleted = editAuthorRequest.IsDeleted;

        await _authorRepository.UpdateAsync(author);
        return _mapper.Map<AuthorResponse>(author);
    }

    public async Task<bool> DeleteAuthor(DeleteAuthorRequest deleteAuthorRequest)
    {
        var author = await _authorRepository.GetByIdAsync(deleteAuthorRequest.Authorid);
        ValidationHelper.AuthorValidation(author);
        var bookauthor = await _bookAuthorRepository.LoadAsync();
        if (bookauthor.Any(x => x.Id == deleteAuthorRequest.Authorid && x.IsDeleted == false))
            throw new BadRequestException($"Please Delete all books for  {author.Firstname} {author.LastName} author");

        await _authorRepository.RemoveAsync(author);
        return true;
    }

    public async Task<AuthorResponse?> GetAuthorById(Guid id)
    {
        var author = await _authorRepository.GetByIdAsync(id) ?? throw new Exception("author not found");
        return new AuthorResponse()
        {
            Firstname = author.Firstname,
            LastName = author.LastName,
            Id = author.Id
        };
    }

    public async Task<IEnumerable<AuthorResponse>?> GetAllAuthors()
    {
        var result = await _authorRepository.LoadAsync();

        if (result.Any())
        {
            return result.Select(x => new AuthorResponse()
            {
                Firstname = x.Firstname,
                LastName = x.LastName,
                Id = x.Id
            });
        }
        return null;
    }
}