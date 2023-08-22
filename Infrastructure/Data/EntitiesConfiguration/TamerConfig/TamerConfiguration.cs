using Core.Entities.Tamer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.TamerConfig
{
    public class TamerConfiguration : IEntityTypeConfiguration<Tamer>
    {
        public void Configure(EntityTypeBuilder<Tamer> builder)
        {
            builder.ToTable("tamer");
            builder.HasKey(opt => opt.Id).HasName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");

            builder.Property(x => x.AT).HasColumnName("at");
            builder.Property(x => x.DE).HasColumnName("de");
            builder.Property(x => x.DS).HasColumnName("ds");
            builder.Property(x => x.HP).HasColumnName("hp");

            builder.HasOne(x => x.TamerSkill).WithOne(x => x.Tamer)
            .HasForeignKey<TamerSkill>(x => x.TamerId).HasConstraintName("id_tamer");
        }
    }
}