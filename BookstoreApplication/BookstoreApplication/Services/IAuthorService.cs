using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using BookstoreApplication.Utils;

namespace BookstoreApplication.Services
{
    public interface IAuthorService
    {
        Task Add(Author author);
        Task<bool> Delete(int id);
        Task<List<Author>> GetAll();
        Task<Author?> GetOne(int id);
        Task Update(Author author);
        Task<PaginatedList<AuthorDTO>> GetAllPaged(int page);
    }
}