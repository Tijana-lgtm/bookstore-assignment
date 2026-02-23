using BookstoreApplication.DTOs;

namespace BookstoreApplication.Services
{
    public interface IAuthService
    {
        Task RegisterAsync(RegistrationDTO data);
        Task LoginAsync(LoginDTO data);
    }
}