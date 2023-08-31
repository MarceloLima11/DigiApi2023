using Core.Entities.Digimon;
using Core.Interfaces.DigimonManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.DigimonManagement
{
    public class EvolutionItemRepository : RepositoryBase<EvolutionItem>, IEvolutionItemRepository
    {
        public EvolutionItemRepository(ApplicationDbContext _context) : base(_context)
        { }
    }
}