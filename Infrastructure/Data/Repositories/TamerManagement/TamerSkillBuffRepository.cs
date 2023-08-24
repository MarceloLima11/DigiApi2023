using Core.Entities.Tamer.Buff;
using Core.Interfaces.TamerManagement;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories.Base;

namespace Infrastructure.Data.Repositories.TamerManagement
{
    public class TamerSkillBuffRepository : RepositoryBase<TamerSkillBuff>, ITamerSkillBuffRepository
    {
        public TamerSkillBuffRepository(ApplicationDbContext context) : base(context)
        { }
    }
}