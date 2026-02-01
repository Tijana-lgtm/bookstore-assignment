using BookstoreApplication.DTOs;
using BookstoreApplication.Models;

namespace BookstoreApplication.Services
{
    public interface IBookService
    {
        Task Add(Book book);
        Task<bool> Delete(int id);
        Task<List<BookDTO>> GetAll();
        Task<BookDetailsDTO> GetOne(int id);
        Task Update(Book book);
    }
}