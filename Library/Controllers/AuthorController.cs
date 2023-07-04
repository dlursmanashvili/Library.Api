using Library.Models.Models.Authors.CommandModel;
using Library.Models.Models.Books.CommandModel;
using Library.Service.IServices;
using Library.Service.Services;
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

        /// <summary>
        /// Creates Author of the book.
        /// </summary>
        /// <param name="createAuthorRequest"></param>
        [Authorize]
        [HttpPost]
        [ProducesResponseType(typeof(AuthorResponse), 201)]
        public async Task<IActionResult> Create(CreateAuthorRequest createAuthorRequest)
        {
            var result = await _authorService.CreateAuthor(createAuthorRequest);
            return CreatedAtAction("GetAll", result);
        }
                    
        /// <summary>        /// Updates info about author.
        /// </summary>
        /// <param name="editAuthorRequest"></param>
        [Authorize]
        [HttpPut]
        [ProducesResponseType(typeof(AuthorResponse), 200)]
        public async Task<IActionResult> Update(EditAuthorRequest editAuthorRequest)
            => Ok(await _authorService.UpdateAuthor(editAuthorRequest));


        /// <summary>
        /// Gets current author by given Id.
        /// </summary>
        /// <param name="id"></param>
        [Authorize]
        [HttpGet]
        [Route("GetAuthorById/{id}")]
        [ProducesResponseType(typeof(AuthorResponse), 200)]
        public async Task<IActionResult> GetById(Guid id)
          => Ok(await _authorService.GetAuthorById(id));

        /// <summary>
        /// Gets list of authors.
        /// </summary>
        [Authorize]
        [HttpGet]
        [Route("GetAllAuthors")]
        [ProducesResponseType(typeof(AuthorResponse), 200)]
        public async Task<IActionResult> GetAll()
            => Ok(await _authorService.GetAllAuthors());

        /// <summary>
        /// Deletes author.
        /// </summary>
        /// <param name="deleteAuthorRequest"></param>
        [Authorize]
        [HttpDelete]
        [ProducesResponseType(204)]
        public async Task<IActionResult> Delete(DeleteAuthorRequest deleteAuthorRequest)
        {
            await _authorService.DeleteAuthor(deleteAuthorRequest);
            return NoContent();
        }

        /// <summary>
        /// Search list of Books by FirstName.
        /// </summary>
        [Authorize]
        [HttpGet("SearchAuthor/{FirstName}")]
        public async Task<IActionResult> Search(string FirstName)
            => Ok(await _authorService.SearchAuthor(FirstName));
    }
}

