namespace Application.DTOs.TamerManagement
{
    public class TamerDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int HP { get; set; }
        public int DS { get; set; }
        public int DE { get; set; }
        public int AT { get; set; }

        public SkillDTO Skill { get; set; }
    }
}