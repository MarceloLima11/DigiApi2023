using Core.Entities.Tamer;
using Core.Entities.Tamer.Buff;

namespace Core.Entities.Intermediate
{
    public record TamerSkillBuffIntermediate
    {
        public int TamerSkillBuffId { get; set; }
        public TamerSkillBuff TamerSkillBuff { get; set; }


        public int TamerSkillId { get; set; }
        public TamerSkill TamerSkill { get; set; }
    }
}