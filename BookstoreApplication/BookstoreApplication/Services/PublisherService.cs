using BookstoreApplication.Models;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class PublisherService
    {
        private readonly PublisherRepository _publisherRepository;

        public PublisherService(AppDbContext context)
        {
            _publisherRepository = new PublisherRepository(context);
        }

        public async Task<List<Publisher>> GetAll()
        {
            return await _publisherRepository.GetAllAsync();
        }

        public async Task<Publisher?> GetOne(int id)
        {
            return await _publisherRepository.GetByIdAsync(id);
        }
        public async Task Add(Publisher publisher)
        {
            await _publisherRepository.AddAsync(publisher);
        }

        public async Task Update(Publisher publisher)
        {
            await _publisherRepository.UpdateAsync(publisher);
        }

        public async Task<bool> Delete(int id)
        {
            return await _publisherRepository.DeleteAsync(id);
        }
    }
}
