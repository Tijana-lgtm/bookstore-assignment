using BookstoreApplication.Models;
using BookstoreApplication.Utils;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        private AppDbContext _context;
        private const int PageSize = 5;

        public AuthorRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Author>> GetAllAsync()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author?> GetByIdAsync(int id)
        {
            return await _context.Authors.FindAsync(id);
        }

        public async Task<Author> AddAsync(Author author)
        {
            _context.Authors.Add(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<Author> UpdateAsync(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Author? author = await _context.Authors.FindAsync(id);
            if (author == null)
            {
                return false;
            }
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<PaginatedList<Author>> GetAllPaged(int page)
        {
            int pageIndex = page - 1;
            var count = await _context.Authors.CountAsync();  
            var items = await _context.Authors                
                .Skip(pageIndex * PageSize)
                .Take(PageSize)
                .ToListAsync();

            return new PaginatedList<Author>(items, count, pageIndex, PageSize);
        }
    }
}