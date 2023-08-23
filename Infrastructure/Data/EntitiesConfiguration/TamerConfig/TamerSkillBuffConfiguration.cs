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
            builder.HasKey(opt => opt.Id).HasName("id_tsb");

            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.FirstBuffAttribute).HasColumnName("first_attribute");
            builder.Property(x => x.SeccondBuffAttribute).HasColumnName("seccond_attribute");

            builder.Property(x => x.FirstBuffAttribute).HasConversion<int>();
            builder.Property(x => x.SeccondBuffAttribute).HasConversion<int>();
        }
    }
}