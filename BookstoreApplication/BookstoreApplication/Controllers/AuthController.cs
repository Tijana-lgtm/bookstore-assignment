using System.Security.Claims;
using BookstoreApplication.DTOs;
using BookstoreApplication.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
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
            if (User.Identity?.IsAuthenticated == true)
            {
                return BadRequest("Already logged in.");
            }

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
            if (User.Identity?.IsAuthenticated == true)
            {
                return BadRequest("Already logged in.");
            }

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var token = await _authService.LoginAsync(data);
            return Ok(token);
        }
        [Authorize]
        [HttpGet("profile")]
        public async Task<IActionResult> Profile()
        {
            return Ok(await _authService.GetProfile(User));
        }

        [HttpGet("google-login")]
        public IActionResult GoogleLogin()
        {
            var properties = new AuthenticationProperties { RedirectUri = "/api/Auth/google-response" };
            return Challenge(properties, "Google");
        }

        [HttpGet("google-response")]
        public async Task<IActionResult> GoogleResponse()
        {
            var result = await HttpContext.AuthenticateAsync("Google");

            if (!result.Succeeded)
                return Unauthorized();

            var email = result.Principal.FindFirst(ClaimTypes.Email)?.Value;
            var name = result.Principal.FindFirstValue(ClaimTypes.GivenName);
            var surname = result.Principal.FindFirstValue(ClaimTypes.Surname);

            if (email == null)
                return BadRequest("Email not found in Google login response.");

            var token = await _authService.LoginWithGoogle(email, name, surname);

            var frontendUrl = $"http://localhost:5173/google-callback?token={token}";
            return Redirect(frontendUrl);
        }
    }
}