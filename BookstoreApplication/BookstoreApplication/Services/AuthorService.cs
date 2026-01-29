using BookstoreApplication.Models;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorService (AppDbContext context)
        {
            _authorRepository = new AuthorRepository (context);
        }

        public async Task<List<Author>> GetAll()
        {
            return await _authorRepository.GetAllAsync();
        }

        public async Task<Author?> GetOne(int id)
        {
            return await _authorRepository.GetByIdAsync(id);
        }
        public async Task Add(Author author)
        {
            await _authorRepository.AddAsync(author);
        }

        public async Task Update(Author author)
        {
            await _authorRepository.UpdateAsync(author);
        }

        public async Task<bool> Delete(int id)
        {
            return await _authorRepository.DeleteAsync(id);
        }
    }
}
