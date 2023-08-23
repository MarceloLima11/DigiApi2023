using Core.Entities.Digimon;
using Core.Entities.Tamer;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void DataSeed(this ModelBuilder builder)
        {
            TamerSeed(builder);
            DigimonSeed(builder);
        }

        private static void TamerSeed(this ModelBuilder builder)
        {
            Tamer t1 = new Tamer(1, "Keenan Crier", "How opposed to the other members of DATS, Marcus Damon, Yoshino Fujieda, and Thomas H. Norstein, Keenan did not live in the human world, nor did he originally have a particular liking for it.", 10, 80, 90, 1, 1);

            builder.Entity<Tamer>().HasData(
                t1
            );
        }

        private static void TamerSkillSeed(this ModelBuilder builder)
        {
            // builder.Entity<TamerSkill>().HasData(
            //     new TamerSkill { Id = 1, Name = "Shock", Description = "Critical hit damage increase by 100% for 30 seconds.", CoolDown = 2, TamerSkillBuffId }
            // );
        }

        private static void DigimonSeed(ModelBuilder builder)
        {
            // builder.Entity<Digimon>().HasData(
            //     new Digimon {  }
            // );
        }
    }
}