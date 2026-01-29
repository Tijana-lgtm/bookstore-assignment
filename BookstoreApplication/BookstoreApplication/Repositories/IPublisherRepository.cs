using BookstoreApplication.Models;

namespace BookstoreApplication.Repositories
{
    public interface IPublisherRepository
    {
        Task<Publisher> AddAsync(Publisher publisher);
        Task<bool> DeleteAsync(int id);
        Task<List<Publisher>> GetAllAsync();
        Task<Publisher?> GetByIdAsync(int id);
        Task<Publisher> UpdateAsync(Publisher publisher);
    }
}