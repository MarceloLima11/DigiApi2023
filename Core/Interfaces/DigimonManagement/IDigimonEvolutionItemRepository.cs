using Core.Interfaces.Base;
using Core.Entities.Intermediate;

namespace Core.Interfaces.DigimonManagement
{
    public interface IDigimonEvolutionItemRepository : IRepositoryBase<DigimonEvolutionItemIntermediate>
    {
        Task<IEnumerable<DigimonEvolutionItemIntermediate>> GetDigimonEvolutionItemIntermediatesByDigimon(int id);
    }
}