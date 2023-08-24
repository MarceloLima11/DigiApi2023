using Core.Entities.Tamer;
using Core.Interfaces.Base;

namespace Core.Interfaces.TamerManagement
{
    public interface ITamerRepository : IRepositoryBase<Tamer>
    {
        Task<Tamer> GetTamerAndSkill(int id);
    }
}