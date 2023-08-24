using Core.Entities.Digimon;
using Core.Interfaces.DigimonManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.DigimonManagement
{
    public class FamilyRepository : RepositoryBase<Family>, IFamilyRepository
    {
        public FamilyRepository(ApplicationDbContext context) : base(context)
        { }
    }
}