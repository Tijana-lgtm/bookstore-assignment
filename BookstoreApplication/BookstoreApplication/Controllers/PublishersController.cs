using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;

        public PublishersController(IPublisherService publisherService)
        {
            _publisherService = publisherService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok(await _publisherService.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetOne(int id)
        {
            Publisher? publisher = await _publisherService.GetOne(id);
            if (publisher == null)
            {
                return NotFound();
            }
            return Ok(publisher);
        }

        [HttpPost]
        public async Task<IActionResult> Post(Publisher publisher)
        {
            publisher.Id = 0;
            await _publisherService.Add(publisher);
            return Ok(publisher);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, Publisher publisher)
        {
            if (id != publisher.Id)
            {
                return BadRequest();
            }

            await _publisherService.Update(publisher);
            return Ok(publisher);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            bool deleted = await _publisherService.Delete(id);
            if (!deleted)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}