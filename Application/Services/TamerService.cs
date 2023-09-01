using Core.Entities.Tamer;
using Application.Interfaces;
using Core.Entities.Tamer.Buff;
using Core.Interfaces.UnitOfWork;
using Application.DTOs.TamerManagement;

namespace Application.Services
{
    public class TamerService : ITamerService
    {
        protected readonly IUnitOfWork _unit;

        public TamerService(IUnitOfWork unit)
        { _unit = unit; }

        public async Task<IEnumerable<TamerDTO>> GetTamers()
        {
            try
            {
                var tamersDTO = new List<TamerDTO>();
                var tamers = await _unit.TamerRepository.GetAll();

                foreach (Tamer tamer in tamers)
                {
                    var skill = await _unit.TamerSkillRepository.GetById(tamer.TamerSkillId);
                    var buff = await _unit.TamerSkillBuffRepository.GetById(skill.TamerSkillBuffId);

                    TamerBuffDTO buffDTO = new()
                    {
                        Name = buff.Name,
                        FirstBuffAttribute = buff.FirstBuffAttribute,
                        SeccondBuffAttribute = buff.SeccondBuffAttribute
                    };

                    TamerSkillDTO skillDTO = new()
                    {
                        Name = skill.Name,
                        Description = skill.Description,
                        CoolDown = skill.CoolDown,
                        Buff = buffDTO
                    };

                    tamersDTO.Add(new TamerDTO
                    {
                        Name = tamer.Name,
                        Description = tamer.Description,
                        AT = tamer.AT,
                        DE = tamer.DE,
                        DS = tamer.DS,
                        HP = tamer.HP,
                        Skill = skillDTO
                    });
                }

                return tamersDTO;
            }
            catch
            { throw; }
        }

        public async Task<TamerDTO> GetTamer(int id)
        {
            try
            {
                Tamer tamer = await _unit.TamerRepository.GetById(id);
                var skill = await _unit.TamerSkillRepository.GetById(tamer.TamerSkillId);
                var buff = await _unit.TamerSkillBuffRepository.GetById(skill.TamerSkillBuffId);


                TamerBuffDTO buffDTO = new()
                {
                    Name = buff.Name,
                    FirstBuffAttribute = buff.FirstBuffAttribute,
                    SeccondBuffAttribute = buff.SeccondBuffAttribute
                };

                TamerSkillDTO skillDTO = new()
                {
                    Name = skill.Name,
                    Description = skill.Description,
                    CoolDown = skill.CoolDown,
                    Buff = buffDTO
                };


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