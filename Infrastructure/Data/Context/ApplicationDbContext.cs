using System.Reflection;
using Core.Entities.Digimon;
using Core.Entities.Digimon.Buff;
using Core.Entities.Intermediate;
using Core.Entities.Tamer;
using Core.Entities.Tamer.Buff;
using Infrastructure.Data.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        { }

        public DbSet<Digimon> Digimon => Set<Digimon>();
        public DbSet<DigimonSkill> DigimonSkill => Set<DigimonSkill>();
        public DbSet<DigimonSkillBuff> DigimonSkillBuff => Set<DigimonSkillBuff>();

        public DbSet<Tamer> Tamer => Set<Tamer>();
        public DbSet<TamerSkill> TamerSkill => Set<TamerSkill>();
        public DbSet<TamerSkillBuff> TamerSkillBuff => Set<TamerSkillBuff>();

        // Intermediate
        public DbSet<DigimonFamilyIntermediate> DigimonFamilyIntermediate => Set<DigimonFamilyIntermediate>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);

            ModelBuilderExtensions.DataSeed(builder);
        }
    }
}