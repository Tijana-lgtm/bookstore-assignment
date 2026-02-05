using BookstoreApplication.Models;
using BookstoreApplication.Utils;

namespace BookstoreApplication.Repositories
{
    public interface IAuthorRepository
    {
        Task<Author> AddAsync(Author author);
        Task<bool> DeleteAsync(int id);
        Task<List<Author>> GetAllAsync();
        Task<Author?> GetByIdAsync(int id);
        Task<Author> UpdateAsync(Author author);
        Task<PaginatedList<Author>> GetAllPaged(int page);
    }
}