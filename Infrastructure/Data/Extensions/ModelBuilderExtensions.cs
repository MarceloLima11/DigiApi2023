using Core.Entities.Digimon;
using Core.Entities.Digimon.Buff;
using Core.Entities.Intermediate;
using Core.Entities.Tamer;
using Core.Entities.Tamer.Buff;
using Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        public static void DataSeed(this ModelBuilder builder)
        {
            TamerSkillBuffSeed(builder.Entity<TamerSkillBuff>());
            TamerSkillSeed(builder.Entity<TamerSkill>());
            TamerSeed(builder.Entity<Tamer>());

            FamilySeed(builder.Entity<Family>());
            DigimonSkillBuffSeed(builder.Entity<DigimonSkillBuff>());
            DigimonSeed(builder.Entity<Digimon>());
            DigimonSkillSeed(builder.Entity<DigimonSkill>());
            RidingSeed(builder.Entity<Riding>());
            DigimonRidingSeed(builder.Entity<DigimonRidingIntermediate>());
        }

        private static void TamerSkillBuffSeed(EntityTypeBuilder<TamerSkillBuff> builder)
        {
            TamerSkillBuff tsb1 = new(1, "Rage of Keenan", DigimonAttribute.Vaccine, DigimonAttribute.No);

            builder.HasData(tsb1);
        }

        private static void TamerSkillSeed(EntityTypeBuilder<TamerSkill> builder)
        {
            TamerSkill ts1 = new(1, "Shock", "Critical hit damage increase by 100% for 30 seconds.", 2, 1);

            builder.HasData(ts1);
        }

        private static void TamerSeed(EntityTypeBuilder<Tamer> builder)
        {
            Tamer t1 = new(1, "Keenan Crier", "How opposed to the other members of DATS, Marcus Damon, Yoshino Fujieda, and Thomas H. Norstein, Keenan did not live in the human world, nor did he originally have a particular liking for it.", 10, 80, 90, 1, 1);

            builder.HasData(t1);
        }

        private static void FamilySeed(EntityTypeBuilder<Family> builder)
        {
            Family f1 = new(1, "Deep Savers", "It is abbreviated as DS. Digimon who belong to this field are generally aquatic or polar Digimon, or those who dwell in marine areas.", "DS");

            Family f2 = new(2, "Dragon's Roar", "It is abbreviated as DR. Digimon who belong to this field are generally Digimon of draconic descent, or those who dwell in volcanic areas.", "DR");

            builder.HasData(f1, f2);
        }

        private static void DigimonSkillBuffSeed(EntityTypeBuilder<DigimonSkillBuff> builder)
        {
            DigimonSkillBuff dsb1 = new(1, "Flame", "Inflicts extra damage 5 seconds after the skill (600 damage base + 200 damage per skill increase (4400 max at 20/20))", "35%");

            builder.HasData(dsb1);
        }

        private static void DigimonSkillSeed(EntityTypeBuilder<DigimonSkill> builder)
        {
            DigimonSkill ds1 = new(1, "Fire Rocket", "Surrounds itself in fire and then charge towards its opponent.\n Target randomly gets additional fire damage.", ElementalAttribute.Fire, 4, 58, 2, 2.5f, 1, 1);

            builder.HasData(ds1);
        }

        private static void DigimonSeed(EntityTypeBuilder<Digimon> builder)
        {
            Digimon d1 = new(1, "Flamedramon", "Flamedramon is a Dragon Man Digimon Armor which evolved through the power of the Digi-Egg of Courage, whose names and design are derived from Flame Dramon.", 2651, 1196, 82, 868, 2.323f, "20.81%", 515, "21%", Form.Armor, DigimonAttribute.Vaccine, ElementalAttribute.Fire, true);

            builder.HasData(d1);
        }

        private static void RidingSeed(EntityTypeBuilder<Riding> builder)
        {
            Riding r1 = new(1, "ModeSelector", "TESTEEEEEEE");
            builder.HasData(r1);
        }

        private static void DigimonRidingSeed(EntityTypeBuilder<DigimonRidingIntermediate> builder)
        {
            DigimonRidingIntermediate dri1 = new()
            {
                DigimonId = 1,
                RidingId = 1,
                Quantity = 5
            };

            builder.HasData(dri1);
        }
    }
}