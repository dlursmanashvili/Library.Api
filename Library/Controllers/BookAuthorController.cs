using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Models.BookAuthors.CommandModel;
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

    [HttpPost]
    public async Task<IActionResult> CreateBookAuthor(CreateBookAuthorRequest createBookAuthorRequest)
         => Ok(await _bookAuthorService.CreateBookAuthor(createBookAuthorRequest));

    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookAuthorById(Guid id)
        => Ok(await _bookAuthorService.GetBookAuthorById(id));

    [HttpGet]
    public async Task<IActionResult> GetAllBookAuthors()
        => Ok(await _bookAuthorService.GetAllBookAuthor());


    [HttpPut]
    public async Task<IActionResult> UpdateBookAuthor(EditBookAuthorRequest editBookAuthorRequest)
        => Ok(await _bookAuthorService.UpdateBookAuthor(editBookAuthorRequest));


    [HttpDelete]
    public async Task<IActionResult> DeleteBookAuthor(DeleteBookAuthorRequest deleteBookAuthorRequest)
        => Ok(await _bookAuthorService.DeleteBookAuthor(deleteBookAuthorRequest));
}
