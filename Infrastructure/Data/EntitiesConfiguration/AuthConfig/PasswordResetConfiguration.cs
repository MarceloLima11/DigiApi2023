using Core.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.AuthConfig
{
    public class PasswordResetConfiguration : IEntityTypeConfiguration<PasswordReset>
    {
        public void Configure(EntityTypeBuilder<PasswordReset> builder)
        {
            builder.ToTable("password_reset");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Token).HasColumnName("token");
            builder.Property(x => x.Expiration).HasColumnName("expiration");
            builder.Property(x => x.Expiration).HasConversion(x => x.ToUniversalTime(), x => DateTime.SpecifyKind(x, DateTimeKind.Utc));
            builder.Property(x => x.UserId).HasColumnName("user_id");
        }
    }
}