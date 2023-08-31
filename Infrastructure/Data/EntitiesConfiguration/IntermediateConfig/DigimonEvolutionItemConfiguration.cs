using Core.Entities.Intermediate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.IntermediateConfig
{
    public class DigimonEvolutionItemConfiguration : IEntityTypeConfiguration<DigimonEvolutionItemIntermediate>
    {
        public void Configure(EntityTypeBuilder<DigimonEvolutionItemIntermediate> builder)
        {
            builder.ToTable("digimon_evolutionitem");
            builder.HasKey(x => new { x.DigimonId, x.EvolutionItemId });

            builder.HasOne(x => x.Digimon).WithMany(x => x.EvolutionItens).HasForeignKey(x => x.DigimonId);
            builder.HasOne(x => x.EvolutionItem).WithMany(x => x.Digimons).HasForeignKey(x => x.EvolutionItemId);
        }
    }
}