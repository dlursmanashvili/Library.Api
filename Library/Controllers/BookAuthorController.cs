using Library.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers;


[ApiController]
[Route("api/[controller]")]
public class BookAuthorController : ControllerBase
{
    private readonly IBookAuthorService _bookAuthorService;

    public BookAuthorController(IBookAuthorService bookAuthorService)
    {
        _bookAuthorService = bookAuthorService;
    }

    //[HttpPost]
    //public async Task<IActionResult> CreateBookAuthor(BookAuthor bookAuthor)
    //{
    //    await _bookAuthorService.CreateBookAuthor(bookAuthor);

    //    return Ok();
    //}

    //[HttpGet]
    //public async Task<IActionResult> GetBookAuthorById(Guid id) => Ok(await _bookAuthorService.GetBookAuthorById(id));

    //[HttpGet]
    //public async Task<IActionResult> GetAllBookAuthors()
    //    => Ok(await _bookAuthorService.GetAllBookAuthor());


    //[HttpPut]
    //[Route("UpdateBookAuthor/{id}")]
    //public async Task<IActionResult> UpdateBookAuthor(Guid id, BookAuthor bookAuthor)
    //{
    //    if (id != bookAuthor.Id)
    //    {
    //        return BadRequest();
    //    }

    //    await _bookAuthorService.UpdateBookAuthor(bookAuthor);

    //    return Ok();
    //}

    //[HttpDelete]
    //[Route("DeleteBookAuthor/{id}")]
    //public async Task<IActionResult> DeleteBookAuthor(Guid id)
    //{
    //    var bookAuthor = await _bookAuthorService.GetBookAuthorById(id);

    //    if (bookAuthor == null)
    //    {
    //        return NotFound();
    //    }

    //    await _bookAuthorService.DeleteBookAuthor(bookAuthor);

    //    return Ok();
    //}
}
