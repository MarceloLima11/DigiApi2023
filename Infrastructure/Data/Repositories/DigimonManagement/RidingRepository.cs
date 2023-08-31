using Core.Entities.Digimon;
using Core.Interfaces.DigimonManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.DigimonManagement
{
    public class RidingRepository : RepositoryBase<Riding>, IRidingRepository
    {
        public RidingRepository(ApplicationDbContext _context) : base(_context)
        { }
    }
}