using Core.Entities.Tamer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.TamerConfig
{
    public class TamerSkillConfiguration : IEntityTypeConfiguration<TamerSkill>
    {
        public void Configure(EntityTypeBuilder<TamerSkill> builder)
        {
            builder.ToTable("tamer_skill");
            builder.HasKey(opt => opt.Id).HasName("id_ts");

            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.CoolDown).HasColumnName("cd");

            builder.HasOne(x => x.TamerSkillBuff).WithMany(x => x.TamerSkills)
            .HasForeignKey(x => x.TamerSkillBuffId).HasConstraintName("id_tamer_skill_buff");
        }
    }
}