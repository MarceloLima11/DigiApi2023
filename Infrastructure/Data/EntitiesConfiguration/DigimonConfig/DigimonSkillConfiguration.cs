using Core.Entities.Digimon;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.EntitiesConfiguration.DigimonConfig
{
    public class DigimonSkillConfiguration : IEntityTypeConfiguration<DigimonSkill>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<DigimonSkill> builder)
        {
            builder.ToTable("digimon_skill");
            builder.HasKey(x => x.Id).HasName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");

            builder.Property(x => x.DSConsumed).HasColumnName("ds_consumed");
            builder.Property(x => x.AnimationTime).HasColumnName("animation_time");
            builder.Property(x => x.Attribute).HasColumnName("attribute");
            builder.Property(x => x.CoolDown).HasColumnName("cd");
            builder.Property(x => x.NecessarySkillPoint).HasColumnName("necessary_skill_point");
        }
    }
}