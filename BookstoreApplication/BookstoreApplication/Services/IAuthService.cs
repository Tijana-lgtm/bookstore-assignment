using System.Security.Claims;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationDTO data);
        Task<string> LoginAsync(LoginDTO data);
        Task<ProfileDTO> GetProfile(ClaimsPrincipal userPrincipal);
    }
}