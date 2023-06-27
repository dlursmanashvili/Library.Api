using Library.Models;
using Library.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;

        public AuthorController(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        [HttpPost]
        [Route("AddAuthor")]
        public async Task<IActionResult> CreateAuthor(Author author)
        {
            await _authorService.CreateAuthor(author);
            return Ok();
        }

        [HttpGet]
        [Route("GetAuthorById/{id}")]
        public async Task<IActionResult> GetAuthorById(Guid id)
        {
            var author = await _authorService.GetAuthorById(id);
            if (author == null)
                return NotFound();

            return Ok(author);
        }

        [HttpGet]
        [Route("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
        {
            var authors = await _authorService.GetAllAuthors();
            return Ok(authors);
        }

        [HttpPut]
        [Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> UpdateAuthor(Guid id, Author author)
        {
            if (id != author.Id)
                return BadRequest();

            await _authorService.UpdateAuthor(author);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteAuthor/{id}")]
        public async Task<IActionResult> DeleteAuthor(Guid id)
        {
            var author = await _authorService.GetAuthorById(id);
            if (author == null)
                return NotFound();

            await _authorService.DeleteAuthor(author);
            return Ok();
        }
    }

}

