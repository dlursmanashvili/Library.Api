using Library.Infrastructure.Repositories.Interfaces;
using Library.Models.Models.Authors.CommandModel;
using Library.Service.IServices;
using Microsoft.AspNetCore.Authorization;
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
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateAuthor(CreateAuthorRequest createAuthorRequest)
           => Ok(await _authorService.CreateAuthor(createAuthorRequest));
        [Authorize]
        [HttpPut]
        public async Task<IActionResult> UpdateAuthor(EditAuthorRequest editAuthorRequest)
            => Ok(await _authorService.UpdateAuthor(editAuthorRequest));
        [Authorize]
        [HttpGet]
        [Route("GetAuthorById/{id}")]
        public async Task<IActionResult> GetAuthorById(Guid id)
          => Ok(await _authorService.GetAuthorById(id));
        [Authorize]
        [HttpGet]
        [Route("GetAllAuthors")]
        public async Task<IActionResult> GetAllAuthors()
            => Ok(await _authorService.GetAllAuthors());
        [Authorize]
        [HttpDelete]
        public async Task<IActionResult> DeleteAuthor(DeleteAuthorRequest deleteAuthorRequest)
          => Ok(await _authorService.DeleteAuthor(deleteAuthorRequest));

    }
}

