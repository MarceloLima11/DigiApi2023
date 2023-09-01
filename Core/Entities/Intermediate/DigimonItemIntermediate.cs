namespace Core.Entities.Intermediate
{
    public class DigimonItemIntermediate
    {
        public int DigimonId { get; set; }
        public Digimon.Digimon Digimon { get; set; }

        public int ItemId { get; set; }
        public Item.Item Item { get; set; }

        public int Quantity { get; set; }
    }
}