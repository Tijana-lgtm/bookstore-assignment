using AutoMapper;
using BookstoreApplication.DTOs;
using BookstoreApplication.Models;
using BookstoreApplication.Repositories;
using BookstoreApplication.Utils;

namespace BookstoreApplication.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly IAuthorRepository _authorRepository;
        private readonly IMapper _mapper;
        private const int PageSize = 5;

        public AuthorService(IAuthorRepository authorRepository, IMapper mapper)
        {
            _authorRepository = authorRepository;
            _mapper = mapper;
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
        public async Task<PaginatedList<AuthorDTO>> GetAllPaged(int page)
        {
            var authors = await _authorRepository.GetAllPaged(page);
            var dtos = authors.Items
                .Select(_mapper.Map<AuthorDTO>).ToList();

            return new PaginatedList<AuthorDTO>(dtos, authors.Count, authors.PageIndex, PageSize);
        }
    }
}
