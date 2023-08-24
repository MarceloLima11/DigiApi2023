using Core.Entities.Tamer;
using Core.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories
{
    public class TamerSkillRepository : RepositoryBase<TamerSkill>, ITamerSkillRepository
    {
        public TamerSkillRepository(ApplicationDbContext _context) : base(_context)
        { }
    }
}