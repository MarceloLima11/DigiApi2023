using Core.Entities.Digimon;
using Core.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories
{
    public class FamilyRepository : RepositoryBase<Family>, IFamilyRepository
    {
        public FamilyRepository(ApplicationDbContext context) : base(context)
        { }
    }
}