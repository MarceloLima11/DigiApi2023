using Core.Entities.Tamer;
using Core.Interfaces.TamerManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.TamerManagement
{
    public class TamerSkillRepository : RepositoryBase<TamerSkill>, ITamerSkillRepository
    {
        public TamerSkillRepository(ApplicationDbContext _context) : base(_context)
        { }
    }
}