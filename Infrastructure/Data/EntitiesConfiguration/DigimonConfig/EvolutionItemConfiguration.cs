using Core.Entities.Digimon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.DigimonConfig
{
    public class EvolutionItemConfiguration : IEntityTypeConfiguration<EvolutionItem>
    {
        public void Configure(EntityTypeBuilder<EvolutionItem> builder)
        {
            builder.ToTable("evolution_item");
            builder.HasKey(x => x.Id).HasName("id");

            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Quantity).HasColumnName("quantity");
        }
    }
}