using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Infrastructure.Data.Context
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContextFactory() { }

        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();

            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=dmo_wiki_itens;User Id=wiki_adm;Password=semsenha1;");
            // optionsBuilder.UseNpgsql("Server=ep-nameless-term-77304841.us-east-2.aws.neon.tech;Port=5432;Database=dmowiki;User Id = fl0user;Password=wyatn84EJpPc");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}