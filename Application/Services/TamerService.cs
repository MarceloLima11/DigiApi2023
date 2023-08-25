using Core.Entities.Tamer;
using Application.Interfaces;
using Core.Interfaces.UnitOfWork;
using Application.DTOs.TamerManagement;
using Core.Entities.Tamer.Buff;

namespace Application.Services
{
    public class TamerService : ITamerService
    {
        protected readonly IUnitOfWork _unit;

        public TamerService(IUnitOfWork unit)
        {
            _unit = unit;
        }

        public async Task<IEnumerable<TamerDTO>> GetTamers()
        {
            var tamersDTO = new List<TamerDTO>();
            var tamers = await _unit.TamerRepository.GetAll();

            foreach (Tamer tamer in tamers)
            {
                tamersDTO.Add(new TamerDTO
                {
                    Name = tamer.Name,
                    Description = tamer.Description,
                    AT = tamer.AT,
                    DE = tamer.DE,
                    DS = tamer.DS,
                    HP = tamer.HP
                });
            }

            return tamersDTO;
        }

        public async Task<TamerDTO> GetTamer(int id)
        {
            Tamer tamer = await _unit.TamerRepository.GetById(id);
            TamerDTO tamerDTO = new()
            {
                Name = tamer.Name,
                Description = tamer.Description,
                AT = tamer.AT,
                DE = tamer.DE,
                DS = tamer.DS,
                HP = tamer.HP
            };

            return tamerDTO;
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

        public async Task<string> CreateTamer(CreateTamerDTO tamerDTO)
        {
            try
            {
                var buffDTO = tamerDTO.Skill.Buff;
                var buff = new TamerSkillBuff(buffDTO.Name, buffDTO.FirstBuffAttribute, buffDTO.SeccondBuffAttribute);
                _unit.TamerSkillBuffRepository.Add(buff);
                await _unit.Commit();

                var skillDTO = tamerDTO.Skill;
                var skill = new TamerSkill(skillDTO.Name, skillDTO.Description, skillDTO.CoolDown, buff.Id);
                _unit.TamerSkillRepository.Add(skill);
                await _unit.Commit();

                var tamer = new Tamer(tamerDTO.Name, tamerDTO.Description, tamerDTO.AT, tamerDTO.DE, tamerDTO.DS, tamerDTO.HP, skill.Id);
                _unit.TamerRepository.Add(tamer);
                await _unit.Commit();

                return "Sucesso!";
            }
            catch
            { throw; }
        }
    }
}