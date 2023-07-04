using Library.Models.Models.BookAuthors.CommandModel;
using Library.Service.IServices;
using Microsoft.AspNetCore.Authorization;
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
    /// <summary>
    /// Creates BookAuthor.
    /// </summary>
    /// <param name="createAuthorRequest"></param>
    [Authorize]
    [HttpPost]
    [ProducesResponseType(typeof(BookAuthorResponse), 201)]
    public async Task<IActionResult> Create(CreateBookAuthorRequest createBookAuthorRequest)
    {
        var result = await _bookAuthorService.CreateBookAuthor(createBookAuthorRequest);
        return CreatedAtAction("GetAll", result);
    }

   
    
   

    /// <summary>
    /// Deletes BookAuthor.
    /// </summary>
    /// <param name="deleteBookAuthorRequest"></param>
    /// <returns></returns>
    [Authorize]
    [HttpDelete]
    [ProducesResponseType(204)]
    public async Task<IActionResult> Delete(DeleteBookAuthorRequest deleteBookAuthorRequest)
    {
        await _bookAuthorService.DeleteBookAuthor(deleteBookAuthorRequest);
        return NoContent();
    }
}
