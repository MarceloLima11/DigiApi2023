using Core.Entities.Digimon;
using Core.Entities.Tamer;
using Core.Entities.Tamer.Buff;
using Core.Enums;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void DataSeed(this ModelBuilder builder)
        {
            TamerSkillBuffSeed(builder);
            TamerSkillSeed(builder);
            TamerSeed(builder);
            DigimonSeed(builder);
        }

        private static void TamerSkillBuffSeed(this ModelBuilder builder)
        {
            TamerSkillBuff tsb1 = new TamerSkillBuff(1, "Rage of Keenan", DigimonAttribute.Vaccine, DigimonAttribute.No);

            builder.Entity<TamerSkillBuff>().HasData(tsb1);
        }

        private static void TamerSkillSeed(this ModelBuilder builder)
        {
            TamerSkill ts1 = new TamerSkill(1, "Shock", "Critical hit damage increase by 100% for 30 seconds.", 2, 1);

            builder.Entity<TamerSkill>().HasData(ts1);
        }

        private static void TamerSeed(this ModelBuilder builder)
        {
            Tamer t1 = new Tamer(1, "Keenan Crier", "How opposed to the other members of DATS, Marcus Damon, Yoshino Fujieda, and Thomas H. Norstein, Keenan did not live in the human world, nor did he originally have a particular liking for it.", 10, 80, 90, 1, 1);

            builder.Entity<Tamer>().HasData(
                t1
            );
        }

        private static void DigimonSeed(ModelBuilder builder)
        {
            // builder.Entity<Digimon>().HasData(
            //     new Digimon {  }
            // );
        }
    }
}