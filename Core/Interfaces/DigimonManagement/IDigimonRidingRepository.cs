using Core.Entities.Intermediate;
using Core.Interfaces.Base;

namespace Core.Interfaces.DigimonManagement
{
    public interface IDigimonRidingRepository : IRepositoryBase<DigimonRidingIntermediate>
    {
        Task<IEnumerable<DigimonRidingIntermediate>> GetDigimonRidingIntermediatesByDigimon(int id);
    }
}