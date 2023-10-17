using System.ComponentModel;
using Core.Entities.Digimon;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.DigimonConfig
{
    public class DigimonConfiguration : IEntityTypeConfiguration<Digimon>
    {
        public void Configure(EntityTypeBuilder<Digimon> builder)
        {
            builder.ToTable("digimon");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");
            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");

            builder.Property(x => x.AT).HasColumnName("at");
            builder.Property(x => x.DE).HasColumnName("de");
            builder.Property(x => x.DS).HasColumnName("ds");
            builder.Property(x => x.HP).HasColumnName("hp");
            builder.Property(x => x.AS).HasColumnName("as");
            builder.Property(x => x.CT).HasColumnName("ct");
            builder.Property(x => x.EV).HasColumnName("ev");
            builder.Property(x => x.HT).HasColumnName("ht");
            builder.Property(x => x.Form).HasColumnName("form");
            builder.Property(x => x.Attribute).HasColumnName("attribute");
            builder.Property(x => x.CanBeRiding).HasColumnName("can_riding");
            builder.Property(x => x.ElementalAttribute).HasColumnName("elemental_attribute");

            builder.HasMany(x => x.Skills).WithOne(x => x.Digimon).HasConstraintName("id_digimon");
            builder.HasMany(d => d.Evolutions).WithMany()
            .UsingEntity(j => j.ToTable("digimon_evolution"));

            // EnumConverter
            builder.Property(x => x.Form).HasConversion<int>();
            builder.Property(x => x.Attribute).HasConversion<int>();
            builder.Property(x => x.ElementalAttribute).HasConversion<int>();
        }
    }
}