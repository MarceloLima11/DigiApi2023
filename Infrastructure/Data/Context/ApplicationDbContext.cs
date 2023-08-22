using Core.Entities.Digimon;
using Core.Entities.Tamer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public virtual DbSet<Digimon> Digimons => Set<Digimon>();
        public virtual DbSet<Tamer> Tamers => Set<Tamer>();
        public virtual DbSet<TamerSkill> TamerSkills => Set<TamerSkill>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

        }
    }
}