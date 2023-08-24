using Core.Entities.Tamer;
using Application.Interfaces;
using Core.Interfaces.UnitOfWork;
using Application.DTOs;

namespace Application.Services
{
    public class TamerService : ITamerService
    {
        protected readonly IUnitOfWork _unit;

        public TamerService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<Tamer>> GetTamers()
        {
            return await _unit.TamerRepository.GetAll();
        }

        public async Task<Tamer> GetTamer(int id)
        {
            return await _unit.TamerRepository.GetById(id);
        }

        public async Task<TamerWithSkillAndBuffDTO> GetTamerWithSkillAndBuff(int id)
        {
            try
            {
                Tamer tamer = await _unit.TamerRepository.GetTamerAndSkill(id);
                var buff = await _unit.TamerSkillBuffRepository.GetById(tamer.TamerSkill.TamerSkillBuffId);

                var response = new TamerWithSkillAndBuffDTO
                {
                    TamerName = tamer.Name,
                    TamerDescription = tamer.Description,
                    AT = tamer.AT,
                    DE = tamer.DE,
                    DS = tamer.DS,
                    HP = tamer.HP,
                    SkillName = tamer.TamerSkill.Name,
                    SkillDescription = tamer.TamerSkill.Description,
                    SkillCoolDown = tamer.TamerSkill.CoolDown,
                    BuffName = buff.Name,
                    FirstAttribute = buff.FirstBuffAttribute,
                    SeccondAttribute = buff.SeccondBuffAttribute
                };

                return response;
            }
            catch
            { throw; }
        }
    }
}