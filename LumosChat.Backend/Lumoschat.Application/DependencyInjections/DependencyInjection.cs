using LumosChat.Application.Abstractions;
using LumosChat.Application.Services;
using LumosChat.Application.UsesCases;
using Microsoft.Extensions.DependencyInjection;

namespace LumosChat.Application.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<RegisterUseCaseAsync>();
            services.AddScoped<GetByUsernameUseCaseAsync>();

            return services;
        }
    }
}
