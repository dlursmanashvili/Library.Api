using Library.Models;
using Library.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controller;

[ApiController]
[Route("[controller]")]
public class BookController : ControllerBase
{
    private readonly BookService _bookService;

    public BookController(BookService bookService)
    {
        _bookService = bookService;
    }

    [Route("CreateBook")]
    [HttpPost]
    public async Task<IActionResult> CreateBook(Book book)
    {
        await _bookService.CreateBook(book);
        return Ok();
    }

    [Route("GetBookById")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(Guid id)
    {
        var book = await _bookService.GetBookById(id);
        if (book == null)
            return NotFound();

        return Ok(book);
    }

    [Route("GetAllBooks")]
    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
    {
        var books = await _bookService.GetAllBooks();
        return Ok(books);
    }

    [HttpPut]
    public async Task<IActionResult> UpdateBook(Book book)
    {
        await _bookService.UpdateBook(book);
        return Ok();
    }
    [Route("DeleteBook")]
    [HttpDelete]
    public async Task<IActionResult> DeleteBook(Book book)
    {
        await _bookService.DeleteBook(book);
        return Ok();
    }
}
