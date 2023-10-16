using Application.Interfaces;
using Core.Entities.Tamer.Seal;
using Core.Interfaces.UnitOfWork;
using Application.DTOs.TamerManagement;

namespace Application.Services
{
    public class SealService : ISealService
    {
        private readonly IUnitOfWork _unit;

        public SealService(IUnitOfWork unit)
        { _unit = unit; }

        public async Task<IEnumerable<SealDTO>> GetSeals()
        {
            try
            {
                List<SealDTO> sealsDTO = new();
                var seals = await _unit.SealRepository.GetAll();

                foreach (Seal seal in seals)
                {
                    sealsDTO.Add(new SealDTO(seal.Level, seal.Abilitie, seal.Buff, seal.DigimonId));
                }

                return sealsDTO;
            }
            catch
            { throw; }
        }
    }
}