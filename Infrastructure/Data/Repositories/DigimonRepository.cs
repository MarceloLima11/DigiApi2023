using Core.Interfaces;
using Core.Entities.Digimon;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Repositories
{
    public class DigimonRepository : IDigimonRepository
    {
        protected readonly ApplicationDbContext _context;
        public DigimonRepository(ApplicationDbContext context)
        { _context = context; }

        public async Task<List<Digimon>> GetDigimons()
        {
            return await _context.Digimon.ToListAsync();
        }
    }
}