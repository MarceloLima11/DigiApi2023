using Core.Interfaces.Base;
using Core.Entities.Intermediate;

namespace Core.Interfaces.DigimonManagement
{
    public interface IDigimonFamilyRepository : IRepositoryBase<DigimonFamilyIntermediate>
    {
        Task<IEnumerable<DigimonFamilyIntermediate>> GetDigimonFamilyIntermediatesByDigimon(int id);
    }
}