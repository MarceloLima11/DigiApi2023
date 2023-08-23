using Core.Entities.Tamer;
using Core.Interfaces;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class TamerRepository : ITamerRepository
    {
        protected readonly ApplicationDbContext _context;

        public TamerRepository(ApplicationDbContext context)
        { _context = context; }

        public async Task<List<Tamer>> GetTamers()
        {
            return await _context.Tamer.ToListAsync();
        }
    }
}