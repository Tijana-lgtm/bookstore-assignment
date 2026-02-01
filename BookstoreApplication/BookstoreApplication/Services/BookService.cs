using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;

namespace BookstoreApplication.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;


        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task<List<BookDTO>> GetAll()
        {
            List<Book> books = await _bookRepository.GetAllAsync();

            List<BookDTO> bookDtos = books
                .Select(book => _mapper.Map<BookDTO>(book))
                .ToList();

            return bookDtos;
        }

        public async Task<BookDetailsDTO?> GetOne(int id)
        {
            Book? book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                return null;
            }

            return _mapper.Map<BookDetailsDTO>(book);
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