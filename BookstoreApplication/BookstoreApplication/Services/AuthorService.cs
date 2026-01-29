using BookstoreApplication.Models;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;

        public AuthorService(IAuthorRepository authorRepository)
        {
            _authorRepository = authorRepository;
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
