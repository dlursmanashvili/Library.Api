using Library.Models;
using Library.Service.IServices;
using Library.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controller
{

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
        [Route("CreateBookAuthor")]
        public async Task<IActionResult> CreateBookAuthor(BookAuthor bookAuthor)
        {
            await _bookAuthorService.CreateBookAuthor(bookAuthor);

            return Ok();
        }

        [HttpGet]
        [Route("GetBookAuthorById/{id}")]
        public async Task<IActionResult> GetBookAuthorById(Guid id)
        {
            var bookAuthor = await _bookAuthorService.GetBookAuthorById(id);

            if (bookAuthor == null)
            {
                return NotFound();
            }

            return Ok(bookAuthor);
        }

        [HttpGet]
        [Route("GetAllBookAuthors")]
        public async Task<IActionResult> GetAllBookAuthors()
        {
            var bookAuthors = await _bookAuthorService.GetAllBookAuthor();
            return Ok(bookAuthors);
        }

        [HttpPut]
        [Route("UpdateBookAuthor/{id}")]
        public async Task<IActionResult> UpdateBookAuthor(Guid id, BookAuthor bookAuthor)
        {
            if (id != bookAuthor.Id)
            {
                return BadRequest();
            }

            await _bookAuthorService.UpdateBookAuthor(bookAuthor);

            return Ok();
        }

        [HttpDelete]
        [Route("DeleteBookAuthor/{id}")]
        public async Task<IActionResult> DeleteBookAuthor(Guid id)
        {
            var bookAuthor = await _bookAuthorService.GetBookAuthorById(id);

            if (bookAuthor == null)
            {
                return NotFound();
            }

            await _bookAuthorService.DeleteBookAuthor(bookAuthor);

            return Ok();
        }
    }
}
