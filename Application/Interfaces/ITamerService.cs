using Application.DTOs.TamerManagement;

namespace Application.Interfaces
{
    public interface ITamerService
    {
        Task<TamerDTO> GetTamer(int id);
        Task<IEnumerable<TamerDTO>> GetTamers();
        Task<string> CreateTamer(CreateTamerDTO tamerDTO);
    }
}