using Library.Models.Models.Books.CommandModel;
using Library.Service.IServices;
using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
    [HttpPost]
    public async Task<IActionResult> CreateBook(CreateBookRequest createBookModel)
        => Ok(await _bookService.CreateBook(createBookModel));

    [Authorize]
    [HttpGet]
    [Route("GetBookById/{id}")]
    public async Task<IActionResult> GetBookById(Guid id)
    => Ok(await _bookService.GetBookById(id));
    
    [Authorize]
    [HttpPut]
    public async Task<IActionResult> UpdateBook(UpdateBookRequest updateBookRequest)
        => Ok(await _bookService.UpdateBook(updateBookRequest));
    
    [Authorize]
    [HttpPut]
    [Route("EditBookStatus")]
    public async Task<IActionResult> EditBookStatus(UpdateBookStatusRequest updateBookStatusRequest)
    => Ok(await _bookService.EditBookStatus(updateBookStatusRequest));
    
    [Authorize]
    [HttpGet]
    [Route("GetAllBooks")]
    public async Task<IActionResult> GetAllBooks()
        => Ok(await _bookService.GetAllBooks());
    
    [Authorize]
    [HttpGet]
    [Route("GetBookStatus/{id}")]
    public async Task<IActionResult> GetBookStatus(Guid id)
     => Ok(await _bookService.GetBookStatus(id));

    [Authorize]
    [HttpDelete]
    public async Task<IActionResult> DeleteBook(DeleteBookRequest deleteBookRequest)
       => Ok(await _bookService.DeleteBook(deleteBookRequest));

}
