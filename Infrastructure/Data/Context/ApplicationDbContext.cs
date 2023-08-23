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

        public virtual DbSet<Digimon> Digimon => Set<Digimon>();
        public virtual DbSet<DigimonSkill> DigimonSkill => Set<DigimonSkill>();
        public virtual DbSet<DigimonSkillBuff> DigimonSkillBuff => Set<DigimonSkillBuff>();

        public virtual DbSet<Tamer> Tamer => Set<Tamer>();
        public virtual DbSet<TamerSkill> TamerSkill => Set<TamerSkill>();
        public virtual DbSet<TamerSkillBuff> TamerSkillBuff => Set<TamerSkillBuff>();

        // Intermediate
        public virtual DbSet<DigimonFamilyIntermediate> DigimonFamilyIntermediate => Set<DigimonFamilyIntermediate>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            ModelBuilderExtensions.DataSeed(builder);
        }
    }
}