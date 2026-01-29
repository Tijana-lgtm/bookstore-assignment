using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public interface IAuthorService
    {
        Task Add(Author author);
        Task<bool> Delete(int id);
        Task<List<Author>> GetAll();
        Task<Author?> GetOne(int id);
        Task Update(Author author);
    }
}