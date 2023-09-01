using Core.Entities.Intermediate;
using Core.Interfaces.Base;

namespace Core.Interfaces.DigimonManagement
{
    public interface IDigimonItemRepository : IRepositoryBase<DigimonItemIntermediate>
    {
        Task<IEnumerable<DigimonItemIntermediate>> GetDigimonItemIntermediatesByDigimon(int id);
    }
}