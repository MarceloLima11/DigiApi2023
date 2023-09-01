using Core.Entities.Intermediate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.IntermediateConfig
{
    public class DigimonItemConfiguration : IEntityTypeConfiguration<DigimonItemIntermediate>
    {
        public void Configure(EntityTypeBuilder<DigimonItemIntermediate> builder)
        {
            builder.ToTable("digimon_item");
            builder.HasKey(x => new { x.DigimonId, x.ItemId });

            builder.Property(x => x.Quantity).HasColumnName("quantity");

            builder.HasOne(x => x.Digimon).WithMany(x => x.Itens).HasForeignKey(x => x.DigimonId);
            builder.HasOne(x => x.Item).WithMany(x => x.Digimons).HasForeignKey(x => x.ItemId);
        }
    }
}