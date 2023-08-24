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

    }
}