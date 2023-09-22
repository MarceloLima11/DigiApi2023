using Core.Entities.Digimon.Buff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.DigimonConfig
{
    public class DigimonSkillBuffConfiguration : IEntityTypeConfiguration<DigimonSkillBuff>
    {
        public void Configure(EntityTypeBuilder<DigimonSkillBuff> builder)
        {
            builder.ToTable("digimon_skill_buff");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.ActivationPercentage).HasColumnName("activation_percentage");
        }
    }
}