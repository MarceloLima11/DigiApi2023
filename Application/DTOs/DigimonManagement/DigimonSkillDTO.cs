using Core.Enums;

namespace Application.DTOs.DigimonManagement
{
    public class DigimonSkillDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public ElementalAttribute Attribute { get; set; }
        public int CoolDown { get; set; }
        public int DSConsumed { get; set; }
        public int NecessarySkillPoint { get; set; }
        public float AnimationTime { get; set; }
        public bool ASB { get; set; }
        public DigimonBuffDTO? Buff { get; set; }
    }
}