using BookstoreApplication.Repositories;
using BookstoreApplication.Models;
using Microsoft.AspNetCore.Mvc;
using BookstoreApplication.Services;


namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly AuthorService _authorService;
        
        public AuthorsController(AppDbContext context)
        {
            _authorService = new AuthorService(context);
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _authorService.GetAll());
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            Author? author = await _authorService.GetOne(id);
            if (author == null)
            {
                return NotFound();
            }
            return Ok(author);
        }

        
        [HttpPost]
        public async Task<IActionResult> Post(Author author)
        {
            author.Id = 0;
            await _authorService.Add(author);
            return Ok(author);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Author author)
        {
            if (id != author.Id)
            {
                return BadRequest();
            }
            
           await _authorService.Update(author);
           return Ok(author);
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _authorService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }

            return NoContent();
        }
    }
}
