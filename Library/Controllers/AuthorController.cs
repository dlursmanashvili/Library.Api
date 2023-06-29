using Library.Models.Models.Authors.CommandModel;
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
        public async Task<IActionResult> CreateAuthor(CreateAuthorRequest createAuthorRequest)
           => Ok(await _authorService.CreateAuthor(createAuthorRequest));

        [HttpGet]
        [Route("GetAuthorById/{id}")]
        public async Task<IActionResult> GetAuthorById(Guid id)
            => Ok(await _authorService.GetAuthorById(id));

        [HttpGet]
        [Route("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
            => Ok(await _authorService.GetAllAuthors());

        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(EditAuthorRequest editAuthorRequest)
            => Ok(await _authorService.UpdateAuthor(editAuthorRequest));


        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(DeleteAuthorRequest deleteAuthorRequest)
            => Ok(await _authorService.DeleteAuthor(deleteAuthorRequest));

    }
}

