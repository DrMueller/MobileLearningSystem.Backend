using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Mmu.Mls.WebServices.Infrastructure.Settings;

namespace Mmu.Mls.WebServices.Infrastructure.Configurations
{
    public static class AppSettingsConfiguration
    {
        public static void ConfigureAppSettings(IServiceCollection services, IConfigurationRoot configuration)
        {
            services.Configure<AppSettings>(configuration.GetSection(AppSettings.SECTION_NAME));
            services.AddSingleton(configuration);
        }
    }
}