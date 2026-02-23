using BookstoreApplication.DTOs;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookstoreApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegistrationDTO data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _authService.RegisterAsync(data);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTO data)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _authService.LoginAsync(data);
            return Ok();
        }
    }
}