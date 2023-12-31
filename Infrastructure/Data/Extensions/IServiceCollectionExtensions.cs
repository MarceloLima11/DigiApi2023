using Core.Interfaces.Auth;


using Infrastructure.Data.Auth;
using Core.Interfaces.UnitOfWork;
using Infrastructure.Data.Context;

using Microsoft.EntityFrameworkCore;


using Core.Interfaces.TamerManagement;

using Core.Interfaces.DigimonManagement;
using Microsoft.Extensions.Configuration;

using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Data.Repositories.UnitOfWork;
using Infrastructure.Data.Repositories.DigimonManagement;
using Infrastructure.Data.Repositories.TamerManagement;

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
            var connectionString = configuration.GetConnectionString("ServerConnection");

            services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseNpgsql(connectionString);
                //options.EnableSensitiveDataLogging();
                //options.LogTo(Console.WriteLine);
            });
        }

        public static void AddRepository(this IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IAuthenticateUser, AuthenticateUser>();

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