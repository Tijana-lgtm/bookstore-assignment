using BookstoreApplication.Models;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class BookService
    {
        private readonly BookRepository _bookRepository;

        public BookService(AppDbContext context)
        {
            _bookRepository = new BookRepository(context);
        }

        public async Task<List<Book>> GetAll()
        {
            return await _bookRepository.GetAllAsync();
        }

        public async Task<Book?> GetOne(int id)
        {
            return await _bookRepository.GetByIdAsync(id);
        }
        public async Task Add(Book book)
        {
            await _bookRepository.AddAsync(book);
        }

        public async Task Update(Book book)
        {
            await _bookRepository.UpdateAsync(book);
        }

        public async Task<bool> Delete(int id)
        {
            return await _bookRepository.DeleteAsync(id);
        }
    }
}