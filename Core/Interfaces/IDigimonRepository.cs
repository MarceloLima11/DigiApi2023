using Core.Entities.Digimon;

namespace Core.Interfaces
{
    public interface IDigimonRepository
    {
        Task<List<Digimon>> GetDigimons();
    }
}