using Application.DTOs;
using Core.Entities.Tamer;

namespace Application.Interfaces
{
    public interface ITamerService
    {
        Task<Tamer> GetTamer(int id);
        Task<IEnumerable<Tamer>> GetTamers();
        Task<TamerWithSkillAndBuffDTO> GetTamerWithSkillAndBuff(int id);
    }
}