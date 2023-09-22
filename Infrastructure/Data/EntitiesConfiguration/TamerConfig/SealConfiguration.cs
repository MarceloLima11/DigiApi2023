using Core.Entities.Tamer.Seal;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.TamerConfig
{
    public class SealConfiguration : IEntityTypeConfiguration<Seal>
    {
        public void Configure(EntityTypeBuilder<Seal> builder)
        {
            builder.ToTable("seal");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Abilitie).HasColumnName("abilitie");
            builder.Property(x => x.Level).HasColumnName("level").HasConversion<int>();
            builder.Property(x => x.Buff).HasColumnName("buff");
            builder.HasOne(x => x.Digimon).WithOne()
                .HasForeignKey<Seal>(seal => seal.DigimonId).IsRequired();
        }
    }
}