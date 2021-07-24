using Microsoft.Extensions.DependencyInjection;
using NxShort.Domain.Menu.Services;

namespace NxShort.Configurations
{
    public static class DependencyInjectionConfiguration
    {
        public static IServiceCollection ConfigureDependencies(this IServiceCollection services)
        {
            services.AddScoped<IMenuService, MenuService>();
            services.AddSingleton<MainWindow>();

            return services;
        }
    }
}
