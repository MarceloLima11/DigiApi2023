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

            optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=dmo_wiki_dev;User Id=wiki_adm;Password=semsenha1;");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}