using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public interface IPublisherService
    {
        Task Add(Publisher publisher);
        Task<bool> Delete(int id);
        Task<List<Publisher>> GetAll();
        Task<Publisher?> GetOne(int id);
        Task Update(Publisher publisher);
    }
}