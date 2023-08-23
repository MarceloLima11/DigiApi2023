using Application.Interfaces;
using Core.Entities.Digimon;
using Core.Interfaces;

namespace Application.Services
{
    public class DigimonService : IDigimonService
    {
        protected readonly IDigimonRepository _digimonRepository;

        public DigimonService(IDigimonRepository digimonRepository)
        { _digimonRepository = digimonRepository; }

        public async Task<List<Digimon>> GetDigimons()
        {
            return await _digimonRepository.GetDigimons();
        }
    }
}