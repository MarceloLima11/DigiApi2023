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

        private static void TamerSeed(ModelBuilder builder)
        {
            builder.Entity<Tamer>().HasData(
                new Tamer { Name = "Marcus Damon", Description = "MARCOOOOOOO!", AT = 10, HP = 90, DS = 80, DE = 2, }
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