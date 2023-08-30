using Core.Entities.Intermediate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.IntermediateConfig
{
    public class DigimonRidingConfiguration : IEntityTypeConfiguration<DigimonRidingIntermediate>
    {
        public void Configure(EntityTypeBuilder<DigimonRidingIntermediate> builder)
        {
            builder.ToTable("digimon_riding");
            builder.HasKey(dr => new { dr.DigimonId, dr.RidingId });
            builder.Property(x => x.Quantity).HasColumnName("quantity");

            builder.HasOne(x => x.Digimon).WithMany(x => x.Ridings).HasForeignKey(x => x.DigimonId);
            builder.HasOne(x => x.Riding).WithMany(x => x.Digimons).HasForeignKey(x => x.RidingId);
        }
    }
}