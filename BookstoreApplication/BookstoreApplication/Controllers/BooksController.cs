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
        private readonly BookService _bookService;
        private readonly AuthorRepository _authorRepository;
        private readonly PublisherRepository _publisherRepository;

        public BooksController(AppDbContext context)
        {
            _bookService = new BookService(context);
            _authorRepository = new AuthorRepository(context);
            _publisherRepository = new PublisherRepository(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _bookService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            Book? book = await _bookService.GetOne(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Book book)
        {
            Author? author = await _authorRepository.GetByIdAsync(book.AuthorId);
            if (author == null)
            {
                return BadRequest();
            }

            Publisher? publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);
            if (publisher == null)
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

            Author? author = await _authorRepository.GetByIdAsync(book.AuthorId);
            if (author == null)
            {
                return BadRequest();
            }

            Publisher? publisher = await _publisherRepository.GetByIdAsync(book.PublisherId);
            if (publisher == null)
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