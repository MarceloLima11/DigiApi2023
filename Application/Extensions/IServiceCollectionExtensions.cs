using Application.Services;
using Application.Interfaces;
using Application.Services.Auth;
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
            services.AddSingleton<IJwtService, JwtService>();
            services.AddTransient<IUserService, UserService>();

            services.AddScoped<ISendEmailService, SendEmailService>();

            services.AddTransient<ITamerService, TamerService>();
            services.AddTransient<IDigimonService, DigimonService>();
            services.AddTransient<IItemService, ItemService>();
        }
    }
}