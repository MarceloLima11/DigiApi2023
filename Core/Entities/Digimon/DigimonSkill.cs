using Core.Common;
using Core.Entities.Digimon.Buff;
using Core.Enums;
using Core.Validations;

namespace Core.Entities.Digimon
{
    public class DigimonSkill : BaseEntity
    {
        public DigimonSkill() { }

        public DigimonSkill(int id, string name, string description, ElementalAttribute attribute, int cd, int dsConsumed, int necessarySkillPoint, float animationTime, int digimonId, int digimonSkillBuffId)
        {
            DomainException.When(id < 0, "Valor de id inválido.");
            Id = id;

            ValidateDigimonSkill(name, description, attribute, cd, dsConsumed, necessarySkillPoint, animationTime, digimonId, digimonSkillBuffId);
        }

        public DigimonSkill(string name, string description, ElementalAttribute attribute, int cd, int dsConsumed, int necessarySkillPoint, float animationTime, int digimonId, int digimonSkillBuffId)
        {
            ValidateDigimonSkill(name, description, attribute, cd, dsConsumed, necessarySkillPoint, animationTime, digimonId, digimonSkillBuffId);
        }

        public ElementalAttribute Attribute { get; set; }
        public int CoolDown { get; set; }
        public int DSConsumed { get; set; }
        public int NecessarySkillPoint { get; set; }
        public float AnimationTime { get; set; }

        public int DigimonId { get; set; }
        public Digimon Digimon { get; set; }

        public int? DigimonSkillBuffId { get; set; }
        public DigimonSkillBuff DigimonSkillBuff { get; set; }

        public void ValidateDigimonSkill(string name, string description, ElementalAttribute attribute, int cd,
         int dsConsumed, int necessarySkillPoint, float animationTime, int digimonId, int digimonSkillBuffId)
        {
            DomainException.When(String.IsNullOrEmpty(name), "Nome inválido.");

            DomainException.When(String.IsNullOrEmpty(description), "Descrição inválido.");

            DomainException.When(cd < 0, "CoolDown inválido.");

            DomainException.When(dsConsumed < 0, "DS consumido inválido.");

            DomainException.When(necessarySkillPoint < 0, "Necessary Skill Point inválido.");

            DomainException.When(animationTime < 0, "Animation Time inválido.");

            DomainException.When(digimonId < 0, "É obrigatório que a Skill possua um Digimon válido.");

            Name = name;
            CoolDown = cd;
            Attribute = attribute;
            DigimonId = digimonId;
            DSConsumed = dsConsumed;
            Description = description;
            AnimationTime = animationTime;
            NecessarySkillPoint = necessarySkillPoint;

            if (digimonSkillBuffId is 0)
                DigimonSkillBuffId = null;
            else
                DigimonSkillBuffId = digimonSkillBuffId;
        }
    }
}