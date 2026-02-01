using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;
        private readonly IPublisherService _publisherService;

        public BooksController(IBookService bookService, IAuthorService authorService, IPublisherService publisherService)
        {
            _bookService = bookService;
            _authorService = authorService;
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            BookDetailsDTO? bookDto = await _bookService.GetOne(id);
            if (bookDto == null)
            {
                return NotFound();
            }
            return Ok(bookDto);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            Author? author = await _authorService.GetOne(book.AuthorId); if (author == null)
            {
                return BadRequest();
            }

            Publisher? publisher = await _publisherService.GetOne(book.PublisherId); if (publisher == null)
            {
                return BadRequest();
            }

            await _bookService.Add(book);  
            return Ok(book);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            Author? author = await _authorService.GetOne(book.AuthorId); if (author == null)
            {
                return BadRequest();
            }

            Publisher? publisher = await _publisherService.GetOne(book.PublisherId); if (publisher == null)
            {
                return BadRequest();
            }

            await _bookService.Update(book);
            return Ok(book);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _bookService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}