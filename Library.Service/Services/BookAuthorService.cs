using AutoMapper;
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
    private readonly IMapper _mapper;
    public BookAuthorService(
        IBookAuthorRepository bookAuthorRepository,
        IBookRepository bookRepository,
        IAuthorRepository authorRepository,
        IMapper mapper
        )
    {
        _bookAuthorRepository = bookAuthorRepository;
        _bookRepository = bookRepository;
        _authorRepository = authorRepository;
        _mapper = mapper;
    }

    public async Task<BookAuthorResponse> CreateBookAuthor(CreateBookAuthorRequest bookAuthor)
    {
        var book = await _bookRepository.GetByIdAsync(bookAuthor.BookId) ?? throw new Exception("Book not found");
        var author = await _authorRepository.GetByIdAsync(bookAuthor.AuthorId) ?? throw new Exception("Author not found");
        var bookAuthors = new BookAuthor()
        {
            Id = Guid.NewGuid(),
            BookId = book.Id,
            AuthorId = author.Id,
        };
        await _bookAuthorRepository.AddAsync(bookAuthors);
        return _mapper.Map<BookAuthorResponse>(bookAuthors);
    }

    public async Task<BookAuthorResponse> UpdateBookAuthor(EditBookAuthorRequest editBookAuthorRequest)
    {
        var result = _bookAuthorRepository.GetByIdAsync(editBookAuthorRequest.bookAuthorID) ?? throw new Exception("bookAuthor not found");

        var author = await _authorRepository.GetByIdAsync(editBookAuthorRequest.AuthorID);
        if (author == null || author.IsDeleted == true) throw new Exception("Author not found or Author is deleted");

        var book = await _bookRepository.GetByIdAsync(editBookAuthorRequest.BookID);
        if (book == null || book.IsDeleted == true) throw new Exception("Book not found or Book is deleted");

        var bookAuthors = new BookAuthor()
        {
            Id = editBookAuthorRequest.bookAuthorID,
            AuthorId = editBookAuthorRequest.AuthorID,
            BookId = editBookAuthorRequest.BookID,
            IsDeleted = editBookAuthorRequest.IsDeleted
        };
        await _bookAuthorRepository.UpdateAsync(bookAuthors);
        return _mapper.Map<BookAuthorResponse>(bookAuthors);
    }

    public async Task<bool> DeleteBookAuthor(DeleteBookAuthorRequest deleteBookAuthorRequest)
    {
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
        return true;
    }

    public async Task<BookAuthorResponse?> GetBookAuthorById(Guid BookAutrhorID)
    {
        var result = await _bookAuthorRepository.GetByIdAsync(BookAutrhorID) ?? throw new NotFoundException("Result Not Faund");       
        return new BookAuthorResponse()
        {
            Id = result.Id,
            AuthorId = result.AuthorId,
            BookId = result.BookId,

        };
    }

    public async Task<IEnumerable<BookAuthorResponse>?> GetAllBookAuthor()
    {
        var bookAuthors = await _bookAuthorRepository.LoadAsync();
        if (!bookAuthors.Any())
            throw new Exception("bookAuthor not found");

        var result = bookAuthors.Where(x => x.IsDeleted == false)
                    ?.Select(x => new BookAuthorResponse()
                    {
                        Id = x.Id,
                        AuthorId = x.AuthorId,
                        BookId = x.BookId,
                    });

        if (!result.Any())
            throw new Exception("bookAuthor not found");

        return result.ToList();
    }





}
