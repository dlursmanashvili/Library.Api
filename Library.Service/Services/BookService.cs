using AutoMapper;
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
    private readonly IMapper _mapper;

    public BookService(
        IBookRepository bookRepository,
        IMapper mapper
        )
    {
        _bookRepository = bookRepository;
        _mapper = mapper;
    }

    public async Task<BookResponse> CreateBook(CreateBookRequest createBookModel)
    {
        var book = new Book()
        {
            Id = Guid.NewGuid(),
            Title = createBookModel.Title,
            FilePath = createBookModel.FilePath,
            Rating = createBookModel.Rating,
            Description = createBookModel.Description,
            InLibrary = true,
            Image = createBookModel.iamge
        };

        await _bookRepository.AddAsync(book);
        return _mapper.Map<BookResponse>(book);
    }

    public async Task<BookResponse> UpdateBook(UpdateBookRequest updateBookRequest)
    {
        var book = await _bookRepository.GetByIdAsync(updateBookRequest.Bookid);
        if (book == null)
            throw new Exception("book not found");

        book.Title = updateBookRequest.Title;
        book.FilePath = updateBookRequest.FilePath;
        book.Rating = updateBookRequest.Rating;
        book.Description = updateBookRequest.Description;
        book.InLibrary = updateBookRequest.InLibrary;
        book.IsDeleted = updateBookRequest.IsDeleted;
        book.Image = updateBookRequest.Image;

        await _bookRepository.UpdateAsync(book);
        return _mapper.Map<BookResponse>(book);
    }

    public async Task<bool> DeleteBook(DeleteBookRequest deleteBookRequest)
    {

        var book = await _bookRepository.GetByIdAsync(deleteBookRequest.Bookid);
        if (book == null || book.IsDeleted)
            throw new Exception("book not found");

        book.IsDeleted = true;

        await _bookRepository.UpdateAsync(book);
        return true;
    }
    public async Task<GetBookByIdResponse?> GetBookById(Guid id)
    {
        var result = await _bookRepository.GetBookById(id);
        if (result == null)
            throw new BadRequestException("Bad request");

        return result;
    }
    public async Task<IEnumerable<GetAllBooksResponse>> GetAllBooks()
    {
        var result = await _bookRepository.LoadAsync();

        if (result == null)
        {
            throw new Exception("Books not found");
        }

        if (result.Any())
        {
            return result.Select(x =>
            new GetAllBooksResponse()
            {
                Id = x.Id,
                Title = x.Title
            }).ToList();
        }
        return new List<GetAllBooksResponse>();
    }

    public async Task<CoommandResult> GetBookStatus(Guid getBookStatusResponse)
    {
        var result = new CoommandResult();
        var book = await _bookRepository.GetByIdAsync(getBookStatusResponse);
        if (book == null)
            throw new NotFoundException("Book  not found");


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

    public async Task<IEnumerable<BookResponse>?> SearchBooks(string Title)
    {
        var books = await _bookRepository.LoadAsync() ?? throw new NotFoundException("books not foud");

        var filtedBooks = books.Where(x => x.IsDeleted == false && x.Title == Title)?.ToList() ?? throw new NotFoundException("books not foud");

        return filtedBooks.Select(x => new BookResponse() {
            Id = x.Id, 
            Title = x.Title,
            Description = x.Description,
            FilePath = x.FilePath,
            Image = x.Image,
            InLibrary = x.InLibrary,
            PublicationDate = x.PublicationDate,
            Rating = x.Rating
            });
    }
}
