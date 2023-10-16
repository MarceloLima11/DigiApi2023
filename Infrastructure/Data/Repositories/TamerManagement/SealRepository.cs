using Core.Entities.Tamer.Seal;
using Core.Interfaces.Base;
using Core.Interfaces.TamerManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.TamerManagement
{
    public class SealRepository : RepositoryBase<Seal>, ISealRepository
    {
        public SealRepository(ApplicationDbContext _context) : base(_context)
        { }
    }
}