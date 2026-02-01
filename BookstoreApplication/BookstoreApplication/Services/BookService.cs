using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using BookstoreApplication.Exceptions;

namespace BookstoreApplication.Services
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<BookService> _logger;


        public BookService(IBookRepository bookRepository, IMapper mapper, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public async Task<List<BookDTO>> GetAll()
        {
            _logger.LogInformation("Fetching all books.");
            List<Book> books = await _bookRepository.GetAllAsync();

            List<BookDTO> bookDtos = books
                .Select(book => _mapper.Map<BookDTO>(book))
                .ToList();

            return bookDtos;
        }

        public async Task<BookDetailsDTO> GetOne(int id)
        {
            _logger.LogInformation("Fetching book with id {Id}.", id);
            Book? book = await _bookRepository.GetByIdAsync(id);

            if (book == null)
            {
                _logger.LogError("Book with id {Id} not found.", id);
                throw new NotFoundException(id);
            }
            _logger.LogInformation("Successfully fetched book with id {Id}.", id);
            return _mapper.Map<BookDetailsDTO>(book);
        }
        public async Task Add(Book book)
        {
            _logger.LogInformation("Adding new book: {Title}.", book.Title);
            await _bookRepository.AddAsync(book);
            _logger.LogInformation("Successfully added book with id {Id}.", book.Id);
        }

        public async Task Update(Book book)
        {
            _logger.LogInformation("Updating book with id {Id}.", book.Id);
            await _bookRepository.UpdateAsync(book);
            _logger.LogInformation("Successfully updated book with id {Id}.", book.Id);
        }

        public async Task<bool> Delete(int id)
        {
            _logger.LogInformation("Attempting to delete book with id {Id}.", id);
            bool deleted = await _bookRepository.DeleteAsync(id);
            if (deleted)
            {
                _logger.LogInformation("Successfully deleted book with id {Id}.", id);
            }
            else
            {
                _logger.LogWarning("Failed to delete book with id {Id}. Book not found.", id);
            }
            return deleted;
        }
    }
}