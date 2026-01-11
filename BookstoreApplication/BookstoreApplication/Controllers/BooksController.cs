using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private BookRepository _bookRepository;
        private AuthorRepository _authorRepository;
        private PublisherRepository _publisherRepository;

        public BooksController(AppDbContext context)
        {
            _bookRepository = new BookRepository(context);
            _authorRepository = new AuthorRepository(context);
            _publisherRepository = new PublisherRepository(context);
        }

        // GET: api/books
        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(_bookRepository.GetAll());
        }

        // GET api/books/id
        [HttpGet("{id}")]
        public IActionResult GetOne(int id)
        {
            Book? book = _bookRepository.GetById(id);
            if (book == null)
            {
                return NotFound();
            }
            return Ok(book);
        }

        // POST api/books
        [HttpPost]
        public IActionResult Post(Book book)
        {
            Author? author = _authorRepository.GetById(book.AuthorId);
            if (author == null)
            {
                return BadRequest();
            }

            Publisher? publisher = _publisherRepository.GetById(book.PublisherId);
            if (publisher == null)
            {
                return BadRequest();
            }

            Book createdBook = _bookRepository.Add(book);
            return Ok(createdBook);
        }

        // PUT api/books/
        [HttpPut("{id}")]
        public IActionResult Put(int id, Book book)
        {
            if (id != book.Id)
            {
                return BadRequest();
            }

            // izmena knjige je moguca ako je izabran dobar autor
            Author? author = _authorRepository.GetById(book.AuthorId);
            if (author == null)
            {
                return BadRequest();
            }

            // izmena knjige je moguca ako je izabran dobar izdavač
            Publisher? publisher = _publisherRepository.GetById(book.PublisherId);
            if (publisher == null)
            {
                return BadRequest();
            }

            Book updatedBook = _bookRepository.Update(book);
            return Ok(updatedBook);
        }

        // DELETE api/books/id
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            bool deleted = _bookRepository.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}