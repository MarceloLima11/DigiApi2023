using Application.Interfaces;
using Core.Entities.Tamer;
using Core.Interfaces;

namespace Application.Services
{
    public class TamerService : ITamerService
    {
        private readonly ITamerRepository _tamerRepository;

        public TamerService(ITamerRepository tamerRepository)
        { _tamerRepository = tamerRepository; }

        public Task<List<Tamer>> GetTamers()
        {
            return _tamerRepository.GetTamers();
        }
    }
}