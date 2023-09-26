using Core.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.AuthConfig
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("user");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Username).HasColumnName("username");
            builder.Property(x => x.Email).HasColumnName("email");
            builder.Property(x => x.PasswordHash).HasColumnName("password");

            builder.Property(x => x.Id).IsRequired()
                .HasDefaultValueSql("gen_random_uuid()");
        }
    }
}