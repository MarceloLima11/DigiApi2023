using Core.Entities.Tamer.Buff;
using Core.Interfaces;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories
{
    public class TamerSkillBuffRepository : RepositoryBase<TamerSkillBuff>, ITamerSkillBuffRepository
    {
        public TamerSkillBuffRepository(ApplicationDbContext context) : base(context)
        { }
    }
}