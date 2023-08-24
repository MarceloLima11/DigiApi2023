using Application.Interfaces;
using Core.Entities.Digimon;
using Core.Interfaces;
using Core.Interfaces.UnitOfWork;

namespace Application.Services
{
    public class DigimonService : IDigimonService
    {
        protected readonly IUnitOfWork _unit;

        public DigimonService(IUnitOfWork unit)
        { _unit = unit; }

        public async Task<IEnumerable<Digimon>> GetDigimons()
        {
            return await _unit.DigimonRepository.GetAll();
        }

        public async Task<Digimon> GetDigimon(int id)
        {
            return await _unit.DigimonRepository.GetById(id);
        }
    }
}