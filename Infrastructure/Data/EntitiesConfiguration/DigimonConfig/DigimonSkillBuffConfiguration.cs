using Core.Entities.Digimon.Buff;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.EntitiesConfiguration.DigimonConfig
{
    public class DigimonSkillBuffConfiguration : IEntityTypeConfiguration<DigimonSkillBuff>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DigimonSkillBuff> builder)
        {
            builder.ToTable("digimon_skill_buff");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.ActivationPercentage).HasColumnName("activation_percentage");
        }
    }
}