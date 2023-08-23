using Core.Entities.Digimon;

namespace Application.Interfaces
{
    public interface IDigimonService
    {
        Task<List<Digimon>> GetDigimons();
    }
}