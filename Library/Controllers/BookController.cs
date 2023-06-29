using Library.Models.Models.Books.CommandModel;
using Library.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BookController : ControllerBase
{
    private readonly IBookService _bookService;

    public BookController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookRequest createBookModel)
        => Ok(await _bookService.CreateBook(createBookModel));


    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookById(Guid id)
    => Ok(await _bookService.GetBookById(id));

    [HttpGet]
    public async Task<IActionResult> GetAllBooks()
        => Ok(await _bookService.GetAllBooks());

    [HttpPut]
    public async Task<IActionResult> UpdateBook(UpdateBookRequest updateBookRequest)
        => Ok(await _bookService.UpdateBook(updateBookRequest));

    [HttpDelete]
    public async Task<IActionResult> DeleteBook(DeleteBookRequest deleteBookRequest)
        => Ok(await _bookService.DeleteBook(deleteBookRequest));
}
