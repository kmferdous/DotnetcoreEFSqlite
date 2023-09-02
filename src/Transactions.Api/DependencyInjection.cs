using Transactions.Api.Configs;
using Transactions.Application.Interfaces;
using Transactions.Infrastructure.Configs;

namespace Transactions.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApi(this IServiceCollection services)
        {
            services.AddSingleton<IAppConfig, AppConfig>();
            services.AddSingleton<IDbConfig, AppConfig>();

            return services;
        }
    }
}
