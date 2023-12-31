using Core.Enums;

namespace Application.DTOs.DigimonManagement
{
    public class DigimonDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HP { get; set; }
        public int DS { get; set; }
        public int DE { get; set; }
        public int AT { get; set; }
        public float AS { get; set; }
        public string CT { get; set; }
        public int HT { get; set; }
        public string EV { get; set; }
        public Form Form { get; set; }
        public DigimonAttribute Attribute { get; set; }
        public ElementalAttribute ElementalAttribute { get; set; }
        public DigimonSkillDTO Skill { get; set; }
        public List<FamilyDTO> Families { get; set; }
        public List<ItemDTO> Itens { get; set; }
    }
}