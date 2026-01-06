using LumosChat.Application.Contracts.Authentication;
using LumosChat.Application.Contracts.Repositories;
using LumosChat.Infrastructure.Authentication;
using LumosChat.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LumosChat.Infrastructure.DependencyInjections
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            IConfiguration configuration
        )
        {
            services.AddScoped<IUserRepository, UserRepository>();

            services.Configure<JwtSettings>(options =>
            {
                configuration.GetSection(JwtSettings.SectionName).Bind(options);
            });

            services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

            return services;
        }
    }
}
