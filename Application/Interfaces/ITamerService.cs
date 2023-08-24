using Core.Entities.Tamer;
using Application.DTOs.TamerManagement;

namespace Application.Interfaces
{
    public interface ITamerService
    {
        Task<Tamer> GetTamer(int id);
        Task<IEnumerable<Tamer>> GetTamers();
        Task<TamerWithSkillAndBuffDTO> GetTamerWithSkillAndBuff(int id);
        Task<string> CreateTamer(CreateTamerDTO tamerDTO);
    }
}