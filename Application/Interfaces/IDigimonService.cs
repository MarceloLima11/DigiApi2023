using Core.Entities.Digimon;

namespace Application.Interfaces
{
    public interface IDigimonService
    {
        Task<IEnumerable<Digimon>> GetDigimons();
        Task<Digimon> GetDigimon(int id);
    }
}