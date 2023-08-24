using Core.Entities.Tamer;
using Core.Entities.Tamer.Buff;
using Core.Interfaces.Base;

namespace Core.Interfaces
{
    public interface ITamerRepository : IRepositoryBase<Tamer>
    {
        Task<Tamer> GetTamerAndSkill(int id);
    }
}