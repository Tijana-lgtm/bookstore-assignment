using BookstoreApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace BookstoreApplication.Repositories
{
    public class AwardRepository
    {

        private AppDbContext _context;

        public AwardRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Award>> GetAllAsync()
        {
            return await _context.Awards.ToListAsync();
        }

        public async Task<Award?> GetByIdAsync(int id)
        {
            return await _context.Awards.FindAsync(id);
        }

        public async Task<Award> AddAsync(Award award)
        {
            _context.Awards.Add(award);
            await _context.SaveChangesAsync();
            return award;
        }

        public async Task<Award> UpdateAsync(Award award)
        {
            _context.Awards.Update(award);
            await _context.SaveChangesAsync();
            return award;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            Award? award = await _context.Awards.FindAsync(id);
            if (award == null)
            {
                return false;
            }
            _context.Awards.Remove(award);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
