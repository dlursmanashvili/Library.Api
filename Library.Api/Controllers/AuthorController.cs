using Library.Models;
using Library.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controller;

[ApiController]
[Route("[controller]")]
public class AuthorController : ControllerBase
{
    private readonly AuthorService _authorService;

    public AuthorController(AuthorService authorService)
    {
        _authorService = authorService;
    }

    [Route("AddAuthor")]
    [HttpPost]
    public async Task<IActionResult> CreateAuthor(Author author)
    {
        await _authorService.CreateAuthor(author);
        return Ok();
    }

    [Route("GetAuthorById")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetAuthorById(Guid id)
    {
        var author = await _authorService.GetAuthorById(id);
        if (author == null)
            return NotFound();

        return Ok(author);
    }

    [Route("GetAllAuthors")]
    [HttpGet]
    public async Task<IActionResult> GetAllAuthors()
    {
        var authors = await _authorService.GetAllAuthors();
        return Ok(authors);
    }

    [Route("UpdateAuthor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateAuthor(Guid id, Author author)
    {
        if (id != author.Id)
            return BadRequest();

        await _authorService.UpdateAuthor(author);
        return Ok();
    }

    [Route("DeleteAuthor")]
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteAuthor(Guid id)
    {
        var author = await _authorService.GetAuthorById(id);
        if (author == null)
            return NotFound();

        await _authorService.DeleteAuthor(author);
        return Ok();
    }
}
