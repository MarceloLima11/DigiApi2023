using Core.Entities.Tamer;
using Core.Entities.Tamer.Buff;
using Core.Enums;

namespace Application.DTOs
{
    public class TamerWithSkillAndBuffDTO
    {
        public string TamerName { get; set; }
        public string TamerDescription { get; set; }
        public int HP { get; set; }
        public int DS { get; set; }
        public int DE { get; set; }
        public int AT { get; set; }
        public string SkillName { get; set; }
        public string SkillDescription { get; set; }
        public int SkillCoolDown { get; set; }
        public string BuffName { get; set; }
        public DigimonAttribute FirstAttribute { get; set; }
        public DigimonAttribute SeccondAttribute { get; set; }
    }
}