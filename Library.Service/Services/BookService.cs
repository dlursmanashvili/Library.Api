using Library.Infrastructure.FileManagement;
using Library.Infrastructure.HelperClass;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models;
using Library.Models.Models.Books;
using Library.Models.Models.Books.CommandModel;
using Library.Service.IServices;

namespace Library.Service.Services;

public class BookService : IBookService
{
    private readonly IBookRepository _bookRepository;
    private readonly IEmployeeService _employeeService;
    private readonly IFileService _fileService;
    public BookService(IBookRepository bookRepository)
    {
        _bookRepository = bookRepository;
    }

    public async Task<CoommandResult> CreateBook(CreateBookRequest createBookModel)
    {
        var user = await _employeeService.GetEmployeeByEmail(createBookModel.AdminEmail);
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
        var result  = await _bookRepository.GetByIdAsync(id);
        if (result != null)
        {
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
        return null;
    }

    public async Task<IEnumerable<GetBookResponse>> GetAllBooks()
    {
        var result = await _bookRepository.LoadAsync();

        if (result.Any())
        {
            return result.Select(x =>
            new GetBookResponse
            {
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
}
