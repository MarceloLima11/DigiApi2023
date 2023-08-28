using Core.Entities.Auth;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.EntitiesConfiguration.AuthConfig
{
    public class AuthorizedDevelopersConfiguration : IEntityTypeConfiguration<AuthorizedDevelopers>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<AuthorizedDevelopers> builder)
        {
            builder.ToTable("authorized_developers");
            builder.Property(x => x.NickName).HasColumnName("developer_nickname");
        }
    }
}