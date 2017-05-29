using Microsoft.Extensions.Options;

namespace Mmu.Mls.WebServices.Infrastructure.Settings.Implementation
{
    public class AppSettingsService : IAppSettingsService
    {
        public AppSettingsService(IOptions<AppSettings> appSettingsOptions)
        {
            AppSettings = appSettingsOptions.Value;
        }

        public AppSettings AppSettings { get; }
    }
}