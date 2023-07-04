﻿using Library.Models.Models.BookAuthors.CommandModel;
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
    /// Updates info about BookAuthor
    /// </summary>
    /// <param name="editBookAuthorRequest"></param>
    [Authorize]
    [HttpPut]
    [ProducesResponseType(typeof(BookAuthorResponse), 200)]
    public async Task<IActionResult> Update(EditBookAuthorRequest editBookAuthorRequest)
       => Ok(await _bookAuthorService.UpdateBookAuthor(editBookAuthorRequest));

    /// <summary>
    /// Gets current BookAuthor by given Id.
    /// </summary>
    /// <param name="id"></param>
    [Authorize]
    [HttpGet("{id}")]
    [ProducesResponseType(typeof(BookAuthorResponse), 200)]
    public async Task<IActionResult> GetById(Guid id)
        => Ok(await _bookAuthorService.GetBookAuthorById(id));

    /// <summary>
    /// Gets list of authors BookAuthor
    /// </summary>
    [Authorize]
    [HttpGet]
    [ProducesResponseType(typeof(BookAuthorResponse), 200)]
    public async Task<IActionResult> GetAll()
        => Ok(await _bookAuthorService.GetAllBookAuthor());

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
