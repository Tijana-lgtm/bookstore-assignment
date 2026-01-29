using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public interface IBookService
    {
        Task Add(Book book);
        Task<bool> Delete(int id);
        Task<List<Book>> GetAll();
        Task<Book?> GetOne(int id);
        Task Update(Book book);
    }
}