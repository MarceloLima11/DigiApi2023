using Application.DTOs.DigimonManagement;

namespace Application.Interfaces
{
    public interface IDigimonService
    {
        Task<DigimonDTO> GetDigimon(int id);
        Task<IEnumerable<DigimonDTO>> GetDigimons();
        Task<string> CreateDigimon(CreateDigimonDTO digimonDTO);
    }
}