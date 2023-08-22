using Core.Entities.Tamer.Buff;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.TamerConfig
{
    public class TamerSkillBuffConfiguration : IEntityTypeConfiguration<TamerSkillBuff>
    {
        public void Configure(EntityTypeBuilder<TamerSkillBuff> builder)
        {
            builder.ToTable("tamer_skill_buff");
            builder.HasKey(opt => opt.Id).HasName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.FirstBuffAttribute).HasColumnName("first_attribute_buff");
            builder.Property(x => x.FirstBuffAttribute).HasColumnName("seccond_attribute_buff");
        }
    }
}