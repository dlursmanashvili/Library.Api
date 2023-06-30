using Library.Infrastructure.HelperClass;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models;
using Library.Models.Exceptions;
using Library.Models.Models.BookAuthors;
using Library.Models.Models.BookAuthors.CommandModel;
using Library.Service.IServices;

namespace Library.Service.Services;

public class BookAuthorService : IBookAuthorService
{
    private readonly IBookAuthorRepository _bookAuthorRepository;
    private readonly IBookRepository _bookRepository;
    private readonly IAuthorRepository _authorRepository;
    private readonly IEmployeeRepository _employeeRepository;
    public BookAuthorService(IBookAuthorRepository bookAuthorRepository, IBookRepository bookRepository, IAuthorRepository authorRepository, IEmployeeRepository employeeRepository)
    {
        _bookAuthorRepository = bookAuthorRepository;
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _employeeRepository = employeeRepository;
    }

    public async Task<CoommandResult> CreateBookAuthor(CreateBookAuthorRequest bookAuthor)
    {
        var user = await _employeeRepository.GetEmployeeByEmail(bookAuthor.AdminMail);
        if (user == null)
            throw new NotFoundException(" user not found");
        ValidationHelper.UserValidation(user, bookAuthor.AdminMail, true);

        var book = await _bookRepository.GetByIdAsync(bookAuthor.BookId);
        if (book == null) throw new Exception("Book not found");

        var author = await _authorRepository.GetByIdAsync(bookAuthor.AuthorId);
        if (author == null) throw new Exception("Author not found");

        await _bookAuthorRepository.AddAsync(new BookAuthor()
        {
            Id= new Guid(),
            BookId = book.Id,
            AuthorId = author.Id,
        });
        return new CoommandResult();
    }

    public async Task<GetBookAuthorResponse?> GetBookAuthorById(Guid BookAutrhorID)
    {
        var result = await _bookAuthorRepository.GetByIdAsync(BookAutrhorID);
        if (result == null || result.IsDeleted == true)
            throw new NotFoundException("Result Not Faund");

        //var book = await _bookRepository.GetByIdAsync(result.BookId);
        //if (book == null || book.IsDeleted == true)
        //    throw new Exception("Book not found");

        //var author = await _authorRepository.GetByIdAsync(result.AuthorId);
        //if (author == null || author.IsDeleted == true)
        //    throw new Exception("Author not found");

        return new GetBookAuthorResponse()
        {
            BookAuthorID = result.Id,
            AuthorId = result.AuthorId,
            BookId = result.BookId,

        };
    }

    public async Task<IEnumerable<GetBookAuthorResponse>?> GetAllBookAuthor()
    {
        var bookAuthors = await _bookAuthorRepository.LoadAsync();
        if (!bookAuthors.Any())
            throw new Exception("bookAuthor not found");

        var result = bookAuthors.Where(x => x.IsDeleted == false)
                    ?.Select(x => new GetBookAuthorResponse()
                    {
                        BookAuthorID = x.Id,
                        AuthorId = x.AuthorId,
                        BookId = x.BookId,
                    });

        if (!result.Any())
            throw new Exception("bookAuthor not found");

        return result.ToList();
    }

    public async Task<CoommandResult> UpdateBookAuthor(EditBookAuthorRequest editBookAuthorRequest)
    {
        ValidationHelper.GetNullParameterName(editBookAuthorRequest);
        var user = await _employeeRepository.GetEmployeeByEmail(editBookAuthorRequest.AdminMail);
        if (user == null)
            throw new NotFoundException("admin user not found");
        ValidationHelper.UserValidation(user, user.Email, true);

        var result = _bookAuthorRepository.GetByIdAsync(editBookAuthorRequest.bookAuthorID);
        if (result == null)
        {
            throw new Exception("bookAuthor not found");
        }

        var author = await _authorRepository.GetByIdAsync(editBookAuthorRequest.AuthorID);
        if (author == null || author.IsDeleted == true)
            throw new Exception("Author not found or Author is deleted");

        var book = await _bookRepository.GetByIdAsync(editBookAuthorRequest.BookID);
        if (book == null || book.IsDeleted == true)
            throw new Exception("Book not found or Book is deleted");

        await _bookAuthorRepository.UpdateAsync(new BookAuthor()
        {
            Id = editBookAuthorRequest.bookAuthorID,
            AuthorId = editBookAuthorRequest.AuthorID,
            BookId = editBookAuthorRequest.BookID,
            IsDeleted = editBookAuthorRequest.IsDeleted
        });
        return new CoommandResult();
    }

    public async Task<CoommandResult> DeleteBookAuthor(DeleteBookAuthorRequest deleteBookAuthorRequest)
    {
        var user = await _employeeRepository.GetEmployeeByEmail(deleteBookAuthorRequest.AdminMail);
        ValidationHelper.UserValidation(user, deleteBookAuthorRequest.AdminMail, true);

        var book = await _bookRepository.GetByIdAsync(deleteBookAuthorRequest.BookId);
        if (book != null)
            throw new Exception($"please remove the book {book.Title}");

        var author = await _authorRepository.GetByIdAsync(deleteBookAuthorRequest.AuthorId);
        if (author != null)
            throw new Exception($"please remove author {author.Firstname} {author.LastName}");

        var result = await _bookAuthorRepository.GetByIdAsync(deleteBookAuthorRequest.bookAuthorID);
        if (result == null)
            throw new Exception("bookAuthor not found");

        await _bookAuthorRepository.RemoveAsync(result);
        return new CoommandResult();
    }

}
