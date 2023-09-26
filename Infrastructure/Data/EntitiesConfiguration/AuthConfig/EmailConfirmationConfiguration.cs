using Core.Entities.Auth;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.EntitiesConfiguration.AuthConfig
{
    public class EmailConfirmationConfiguration : IEntityTypeConfiguration<EmailConfirmation>
    {
        public void Configure(EntityTypeBuilder<EmailConfirmation> builder)
        {
            builder.ToTable("email_confirmation");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id");

            builder.Property(x => x.Confirmed).HasColumnName("confirmed").HasDefaultValue(false);
            builder.Property(x => x.Token).HasColumnName("token").HasMaxLength(6);
            builder.Property(x => x.Expiration).HasColumnName("expiration"); builder.Property(x => x.Expiration).HasConversion(x => x.ToUniversalTime(), x => DateTime.SpecifyKind(x, DateTimeKind.Utc));

            builder.HasOne(x => x.User).WithOne(x => x.EmailConfirmation)
                .HasForeignKey<EmailConfirmation>(x => x.UserId).IsRequired();
        }
    }
}