using AutoMapper;
using Library.Infrastructure.Repositories.Interfaces;
using Library.Models;
using Library.Models.Exceptions;
using Library.Models.Models.BookAuthors;
using Library.Models.Models.BookAuthors.CommandModel;
using Library.Service.IServices;
using System.Linq;

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

    public async Task<BookAuthorResponse> CreateBookAuthor(CreateBookAuthorRequest request)
    {
        var bookAuthors = new BookAuthor()
        {
            Id = Guid.NewGuid(),
            BookId = request.BookId,
            AuthorId = request.AuthorId,
        };

        await _bookAuthorRepository.AddAsync(bookAuthors);
        return _mapper.Map<BookAuthorResponse>(bookAuthors);
    }

    public async Task<BookAuthorResponse> UpdateBookAuthor(EditBookAuthorRequest request)
    {
        
        var newBook = new BookAuthor() 
        { 
            Id= request.Id,
            BookId = request.BookID,
            AuthorId = request.AuthorID,
            IsDeleted = request.IsDeleted
        };

        await _bookAuthorRepository.UpdateAsync(newBook);
        return _mapper.Map<BookAuthorResponse>(newBook);
    }

    public async Task<bool> DeleteBookAuthor(DeleteBookAuthorRequest request)
    {
        var book = await _bookRepository.GetByIdAsync(request.BookId);
        if (book != null)
            throw new Exception($"please remove the book {book.Title}");

        var author = await _authorRepository.GetByIdAsync(request.AuthorId);
        if (author != null)
            throw new Exception($"please remove author {author.Firstname} {author.LastName}");

        var result = await _bookAuthorRepository.GetByIdAsync(request.bookAuthorID);
        if (result == null)
            throw new Exception("bookAuthor not found");

        await _bookAuthorRepository.RemoveAsync(result);
        return true;
    }

    public async Task<BookAuthorResponse?> GetBookAuthorById(Guid Id)
    {
        var result = await _bookAuthorRepository.GetByIdAsync(Id) ?? throw new NotFoundException("Result Not Faund");
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
