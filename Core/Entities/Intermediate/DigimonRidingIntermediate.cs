using Core.Entities.Digimon;

namespace Core.Entities.Intermediate
{
    public class DigimonRidingIntermediate
    {
        public int DigimonId { get; set; }
        public Digimon.Digimon Digimon { get; set; }

        public int RidingId { get; set; }
        public Riding Riding { get; set; }

        public int Quantity { get; set; }
    }
}