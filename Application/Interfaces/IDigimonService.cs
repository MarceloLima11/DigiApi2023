using Application.DTOs.DigimonManagement;

namespace Application.Interfaces
{
    public interface IDigimonService
    {
        Task<DigimonDTO> GetDigimon(int id);
        Task<IEnumerable<DigimonDTO>> GetDigimons();
        Task<DigimonWithSkillBuffAndFamilyDTO> GetDigimonWithSkillBuffAndFamily(int id);
        Task<string> CreateDigimon(CreateDigimonDTO digimonDTO);
    }
}