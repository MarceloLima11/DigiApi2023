using Core.Entities.Digimon;

namespace Core.Entities.Intermediate
{
    public class DigimonEvolutionItemIntermediate
    {
        public int DigimonId { get; set; }
        public Digimon.Digimon Digimon { get; set; }

        public int EvolutionItemId { get; set; }
        public EvolutionItem EvolutionItem { get; set; }
    }
}
