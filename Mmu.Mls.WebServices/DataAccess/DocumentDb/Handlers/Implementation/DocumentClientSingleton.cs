using System;
using Microsoft.Azure.Documents.Client;
using Mmu.Mls.WebServices.Infrastructure.Settings;

namespace Mmu.Mls.WebServices.DataAccess.DocumentDb.Handlers.Implementation
{
    public class DocumentClientSingleton : IDocumentClientSingleton
    {
        public DocumentClientSingleton(IAppSettingsService appSettingsService)
        {
            var endPointUri = new Uri(appSettingsService.AppSettings.DocumentDbServiceEndpointUrl);
            Instance = new DocumentClient(endPointUri, appSettingsService.AppSettings.DocumentDbAuthKey);
        }

        public DocumentClient Instance { get; }
    }
}