using Library.Infrastructure.FileManagement;
using Library.Infrastructure.HelperClass;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models;
using Library.Models.Exceptions;
using Library.Models.Models.Books;
using Library.Models.Models.Books.CommandModel;
using Library.Service.IServices;

namespace Library.Service.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IEmployeeService _employeeService;
    private readonly IFileService _fileService;
    public BookService(IBookRepository bookRepository, IFileService fileService, IEmployeeService employeeService)
    {
        _bookRepository = bookRepository;
        _fileService = fileService;
        _employeeService = employeeService;
    }

    public async Task<CoommandResult> CreateBook(CreateBookRequest createBookModel)
    {
        var user = await _employeeService.GetEmployeeByEmail(createBookModel.AdminEmail);
        if (user == null)
            throw new NotFoundException(" user not found");
        ValidationHelper.UserValidation(user, createBookModel.AdminEmail, true);

        var book = new Book()
        {
            Id = Guid.NewGuid(),
            Title = createBookModel.Title,
            FilePath = createBookModel.FilePath,
            Rating = createBookModel.Rating,
            Description = createBookModel.Description,
            InLibrary = true,
        };

        await _bookRepository.AddAsync(book);
        return new CoommandResult();
    }

    public async Task<CoommandResult> UpdateBook(UpdateBookRequest updateBookRequest)
    {
        var user = await _employeeService.GetEmployeeByEmail(updateBookRequest.AdminEmail);
        ValidationHelper.UserValidation(user, updateBookRequest.AdminEmail, true);

        var book = await _bookRepository.GetByIdAsync(updateBookRequest.Bookid);
        if (book == null)
            throw new Exception("book not found");

        book.Title = updateBookRequest.Title;
        book.FilePath = updateBookRequest.FilePath;
        book.Rating = updateBookRequest.Rating;
        book.Description = updateBookRequest.Description;
        book.InLibrary = updateBookRequest.InLibrary;
        book.IsDeleted = updateBookRequest.IsDeleted;

        await _bookRepository.UpdateAsync(book);
        return new CoommandResult();
    }

    public async Task<CoommandResult> DeleteBook(DeleteBookRequest deleteBookRequest)
    {
        var user = await _employeeService.GetEmployeeByEmail(deleteBookRequest.AdminEmail);
        ValidationHelper.UserValidation(user, deleteBookRequest.AdminEmail, true);

        var book = await _bookRepository.GetByIdAsync(deleteBookRequest.Bookid);
        if (book == null)
            throw new Exception("book not found");

        await _bookRepository.RemoveAsync(book);
        return new CoommandResult();
    }
    public async Task<GetBookResponse?> GetBookById(Guid id)
    {
        var result = await _bookRepository.GetByIdAsync(id);
        if (result == null)
        {
            throw new Exception("Book not found");
        }

        return new GetBookResponse()
        {
            Rating = result.Rating,
            Description = result.Description,
            InLibrary = result.InLibrary,
            FilePath = result.FilePath,
            PublicationDate = result.PublicationDate,
            Title = result.Title,
        };
    }
    public async Task<IEnumerable<GetBookResponse>> GetAllBooks()
    {
        var result = await _bookRepository.LoadAsync();

        if (result == null)
        {
            throw new Exception("Books not found");
        }

        if (result.Any())
        {
            return result.Select(x =>
            new GetBookResponse
            {
                BookID = x.Id,
                Title = x.Title,
                Description = x.Description,
                InLibrary = x.InLibrary,
                FilePath = x.FilePath,
                PublicationDate = x.PublicationDate,
                Rating = x.Rating
            }).ToList();
        }
        return new List<GetBookResponse>();
    }

    public async Task<CoommandResult> GetBookStatus(Guid getBookStatusResponse)
    {
        var result = new CoommandResult();
        var book = await _bookRepository.GetByIdAsync(getBookStatusResponse);
        if (book == null)
        {
            result = new CoommandResult()
            {
                IsSuccess = false,
                SuccessMassage = $"Book  bot found"
            };
        }
        if (book.IsDeleted)
        {
            result = new CoommandResult()
            {
                IsSuccess = false,
                SuccessMassage = $"Book IsDeleted"
            };
        }
        if (book.InLibrary == true)
            result = new CoommandResult()
            {
                IsSuccess = true,
                SuccessMassage = $"Book In Libray"
            };

        if (book.InLibrary == false)
            result = new CoommandResult()
            {
                IsSuccess = true,
                SuccessMassage = $"The book is not in the library"
            };
        return result;
    }

    public async Task<CoommandResult> EditBookStatus(UpdateBookStatusRequest updateBookStatusRequest)
    {
        var book = await _bookRepository.GetByIdAsync(updateBookStatusRequest.BookId);
        if (book == null)
        {
            return new CoommandResult()
            {
                IsSuccess = false,
                SuccessMassage = $"Book  bot found"
            };
        }
        if (book.IsDeleted)
        {
            return new CoommandResult()
            {
                IsSuccess = false,
                SuccessMassage = $"Book IsDeleted"
            };
        }
        book.InLibrary = updateBookStatusRequest.BookStatus;
        await _bookRepository.UpdateAsync(book);

        if (updateBookStatusRequest.BookStatus == true)
        {
            return new CoommandResult()
            {
                IsSuccess = true,
                SuccessMassage = $"Book Status update is successful book InLibrary "
            };
        }
        else
        {
            return new CoommandResult()
            {
                IsSuccess = true,
                SuccessMassage = $"Book Status update is successful book InLibrary "
            };
        }

    }

}
