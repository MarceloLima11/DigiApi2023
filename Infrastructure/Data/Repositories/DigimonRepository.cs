using Core.Interfaces;
using Core.Entities.Digimon;
using Infrastructure.Data.Context;
using Microsoft.EntityFrameworkCore;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories
{
    public class DigimonRepository : RepositoryBase<Digimon>, IDigimonRepository
    {
        public DigimonRepository(ApplicationDbContext _context) : base(_context)
        { }
    }
}