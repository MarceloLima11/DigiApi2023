using Application.Interfaces;
using Application.Services;
using Core.Interfaces.UnitOfWork;
using Microsoft.Extensions.DependencyInjection;

namespace Application.Extensions
{
    public static class IServiceCollectionExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddServices();
        }

        private static void AddServices(this IServiceCollection services)
        {
            services.AddTransient<ITamerService, TamerService>();
            services.AddTransient<IDigimonService, DigimonService>();
        }
    }
}