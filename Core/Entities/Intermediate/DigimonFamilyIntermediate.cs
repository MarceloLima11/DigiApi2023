using Core.Entities.Digimon;

namespace Core.Entities.Intermediate
{
    public class DigimonFamilyIntermediate
    {
        public int DigimonId { get; set; }
        public Digimon.Digimon Digimon { get; set; }

        public int FamilyId { get; set; }
        public Family Family { get; set; }
    }
}