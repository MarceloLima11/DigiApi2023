using Core.Entities.Item;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.ItemConfig
{
    public class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("item");
            builder.HasKey(x => x.Id).HasName("id");

            builder.Property(x => x.Name).HasColumnName("name");
            builder.Property(x => x.Description).HasColumnName("description");
            builder.Property(x => x.ClassItem).HasConversion<int>().HasColumnName("class");

            builder.HasOne(x => x.ItemType).WithMany();
        }
    }
}