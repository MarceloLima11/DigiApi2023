using Core.Entities.Intermediate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.IntermediateConfig
{
    public class DigimonFamilyConfiguration : IEntityTypeConfiguration<DigimonFamilyIntermediate>
    {
        public void Configure(EntityTypeBuilder<DigimonFamilyIntermediate> builder)
        {
            builder.ToTable("digimon_family");
            builder.HasKey(df => new { df.DigimonId, df.FamilyId });

            builder.HasOne(x => x.Digimon).WithMany(x => x.Families).HasForeignKey(x => x.DigimonId);
            builder.HasOne(x => x.Family).WithMany(x => x.Digimons).HasForeignKey(x => x.FamilyId);
        }
    }
}