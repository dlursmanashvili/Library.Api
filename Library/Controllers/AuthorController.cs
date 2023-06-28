using Library.Models.Models.Authors;
using Library.Service.IServices;
using Microsoft.AspNetCore.Mvc;

namespace Library.Api.Controllers
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
        [Route("AddAuthor/{Email}/{id}")]
        public async Task<IActionResult> CreateAuthor(string Email, Guid id)
        {
            await _authorService.CreateAuthor(Email, id);
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
        [Route("UpdateAuthor/{Email}/{id}")]
        public async Task<IActionResult> UpdateAuthor(string Email, Guid id)
        {
            await _authorService.UpdateAuthor(Email, id);
            return Ok();
        }

        [HttpDelete]
        [Route("DeleteAuthor/{Email}/{id}")]
        public async Task<IActionResult> DeleteAuthor(string Email, Guid id)
            => Ok(await _authorService.DeleteAuthor(Email, id));
        
    }

}

