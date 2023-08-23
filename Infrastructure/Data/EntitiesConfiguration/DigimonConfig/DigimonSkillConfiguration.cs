using Core.Entities.Digimon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.DigimonConfig
{
    public class DigimonSkillConfiguration : IEntityTypeConfiguration<DigimonSkill>
    {
        public void Configure(EntityTypeBuilder<DigimonSkill> builder)
        {
            builder.ToTable("digimon_skill");
            builder.HasKey(x => x.Id).HasName("id_ds");

            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");

            builder.Property(x => x.DSConsumed).HasColumnName("ds_consumed");
            builder.Property(x => x.AnimationTime).HasColumnName("animation_time");
            builder.Property(x => x.Attribute).HasColumnName("attribute");
            builder.Property(x => x.CoolDown).HasColumnName("cd");
            builder.Property(x => x.NecessarySkillPoint).HasColumnName("necessary_skill_point");

            builder.HasOne(x => x.DigimonSkillBuff).WithMany().HasConstraintName("pk_digimon_skill_id");
        }
    }
}