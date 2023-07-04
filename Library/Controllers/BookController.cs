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
    /// <summary>
    /// Create the Book.
    /// </summary>
    /// <param name="createBookRequest"></param>
    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(BookResponse), 201)]
    public async Task<IActionResult> Create(CreateBookRequest createBookRequest)
    {
        var result = await _bookService.CreateBook(createBookRequest);
        return CreatedAtAction("GetAll", result);
    }

    /// <summary>
    /// Updates info about Book.
    /// </summary>
    /// <param name="updateBookRequest"></param>
    [Authorize]
    [HttpPut]
    [ProducesResponseType(typeof(BookResponse), 200)]
    public async Task<IActionResult> Update(UpdateBookRequest updateBookRequest)
      => Ok(await _bookService.UpdateBook(updateBookRequest));

    /// <summary>
    /// Gets current book by given Id.
    /// </summary>
    /// <param name="id"></param>
    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(GetBookByIdResponse), 200)]
    public async Task<IActionResult> GetById(Guid id)
    => Ok(await _bookService.GetBookById(id));

    /// <summary>
    /// Gets list of Books.
    /// </summary>
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(GetAllBooksResponse), 200)]
    public async Task<IActionResult> GetAll()
        => Ok(await _bookService.GetAllBooks());

    /// <summary>
    /// Delete Book
    /// </summary>
    /// <param name="deleteBookRequest"></param>
    [Authorize]
    [HttpDelete]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(DeleteBookRequest deleteBookRequest)
    {
        await _bookService.DeleteBook(deleteBookRequest);
        return NoContent();
    }

    /// <summary>
    /// Edit Status of Books.
    /// </summary>
    /// <param name="updateBookStatusRequest"></param>
    [Authorize]
    [HttpPut]
    [Route("Status")]
    public async Task<IActionResult> EditStatus(UpdateBookStatusRequest updateBookStatusRequest)
  => Ok(await _bookService.EditBookStatus(updateBookStatusRequest));

    /// <summary>
    /// Get Status of Books.
    /// </summary>
    /// <param name="id"></param>
    [Authorize]
    [HttpGet]
    [Route("Status/{id}")]
    public async Task<IActionResult> GetStatus(Guid id)
    => Ok(await _bookService.GetBookStatus(id));


    /// <summary>
    /// Search list of Books by Title.
    /// </summary>
    [Authorize]
    [HttpGet("SearchBook/{Title}")]
    public async Task<IActionResult> Search(string Title)
        => Ok(await _bookService.SearchBooks( Title));
}
