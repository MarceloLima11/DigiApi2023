using Application.Interfaces;
using Core.Entities.Tamer.Title;
using Core.Interfaces.UnitOfWork;
using Application.DTOs.TamerManagement;

namespace Application.Services
{
    public class TitleService : ITitleService
    {
        private readonly IUnitOfWork _unit;

        public TitleService(IUnitOfWork unit)
        { _unit = unit; }


        public async Task<IEnumerable<TitleDTO>> GetTitles()
        {
            try
            {
                var titles = await _unit.TitleRepository.GetAll();
                List<TitleDTO> titlesDTO = new();

                foreach (Title title in titles)
                {
                    var titleDTO = new TitleDTO(title.Name, title.Description, title.Score, title.Effect, title.HowObtained);

                    titlesDTO.Add(titleDTO);
                }

                return titlesDTO;
            }
            catch
            { throw; }
        }

        public async Task<string> CreateTitle(TitleDTO titleDTO)
        {
            try
            {
                Title title = new(titleDTO.Name, titleDTO.Description, titleDTO.Score, titleDTO.Effect, titleDTO.HowObtained);

                _unit.TitleRepository.Add(title);
                await _unit.Commit();

                return "Sucesso!";
            }
            catch
            { throw; }
        }
    }
}