﻿using Library.Models;
using Library.Service;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controller;

[ApiController]
[Route("[controller]")]
public class BookAuthorController : ControllerBase
{
    private readonly BookAuthorService _bookAuthorService;

    public BookAuthorController(BookAuthorService bookAuthorService)
    {
        _bookAuthorService = bookAuthorService;
    }

    [Route("CreateBookAuthor")]
    [HttpPost]
    public async Task<IActionResult> CreateBookAuthor(BookAuthor bookAuthor)
    {
        await _bookAuthorService.CreateBookAuthor(bookAuthor);

        return Ok();
    }

    [Route("GetBookAuthorById")]
    [HttpGet("{id}")]
    public async Task<IActionResult> GetBookAuthorById(Guid id)
    {
        var bookAuthor = await _bookAuthorService.GetBookAuthorById(id);

        if (bookAuthor == null)
        {
            return NotFound();
        }

        return Ok(bookAuthor);
    }

    [Route("GetAllBookAuthors")]
    [HttpGet]
    public async Task<IActionResult> GetAllBookAuthors()
    {
        var bookAuthors = await _bookAuthorService.GetAllBookAuthor();
        return Ok(bookAuthors);
    }

    [Route("UpdateBookAuthor")]
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateBookAuthor(Guid id, BookAuthor bookAuthor)
    {
        if (id != bookAuthor.Id)
        {
            return BadRequest();
        }

        await _bookAuthorService.UpdateBookAuthor(bookAuthor);

        return Ok();
    }

    [Route("DeleteBookAuthor")]
    [HttpDelete("{id}")]
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