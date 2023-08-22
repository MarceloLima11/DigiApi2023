using Core.Common;
using Core.Entities.Digimon.Buff;
using Core.Enums;

namespace Core.Entities.Digimon
{
    public class DigimonSkill : BaseEntity
    {
        public ElementalAttribute Attribute { get; set; }
        public int CoolDown { get; set; }
        public int DSConsumed { get; set; }
        public int NecessarySkillPoint { get; set; }
        public float AnimationTime { get; set; }

        public int DigimonId { get; set; }
        public Digimon Digimon { get; set; }

        public int? DigimonSkillBuffId { get; set; }
        public DigimonSkillBuff DigimonSkillBuff { get; set; }
    }
}