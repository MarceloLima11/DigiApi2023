using Core.Interfaces;
using Core.Interfaces.Base;
using Core.Interfaces.UnitOfWork;
using Infrastructure.Data.Context;
using Infrastructure.Data.Repositories;
using Infrastructure.Data.Repositories.Base;
using Infrastructure.Data.Repositories.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.Data.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddInfrastructureLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext(configuration);
            services.AddRepository();
        }

        public static void AddDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
            });
        }

        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddTransient<ITamerRepository, TamerRepository>();
            services.AddTransient<ITamerSkillRepository, TamerSkillRepository>();
            services.AddTransient<ITamerSkillBuffRepository, TamerSkillBuffRepository>();

            services.AddTransient<IDigimonRepository, DigimonRepository>();
            services.AddTransient<IDigimonSkillRepository, DigimonSkillRepository>();
            services.AddTransient<IDigimonSkillBuffRepository, DigimonSkillBuffRepository>();
            services.AddTransient<IFamilyRepository, FamilyRepository>();
        }
    }
}