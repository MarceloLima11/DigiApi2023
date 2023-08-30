using Core.Entities.Digimon;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.DigimonConfig
{
    public class RidingConfiguration : IEntityTypeConfiguration<Riding>
    {
        public void Configure(EntityTypeBuilder<Riding> builder)
        {
            builder.ToTable("riding").HasKey(x => x.Id).HasName("id");
        }
    }
}