using Library.Models;
using Library.Service.IServices;
using Library.Service.Services;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controller
{

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
        [Route("CreateBook")]
        public async Task<IActionResult> CreateBook(Book book)
        {
            await _bookService.CreateBook(book);
            return Ok();
        }

        [HttpGet]
        [Route("GetBookById/{id}")]
        public async Task<IActionResult> GetBookById(Guid id)
        {
            var book = await _bookService.GetBookById(id);
            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet]
        [Route("GetAllBooks")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _bookService.GetAllBooks();
            return Ok(books);
        }

        [HttpPut]
        [Route("UpdateBook")]
        public async Task<IActionResult> UpdateBook(Book book)
        {
            await _bookService.UpdateBook(book);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteBook")]
        public async Task<IActionResult> DeleteBook(Book book)
        {
            await _bookService.DeleteBook(book);
            return Ok();
        }
    }

}
