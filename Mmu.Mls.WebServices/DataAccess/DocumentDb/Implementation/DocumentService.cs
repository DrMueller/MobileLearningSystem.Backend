using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Documents.Client;
using Mmu.Mls.WebServices.DataAccess.DocumentDb.Handlers;
using Mmu.Mls.WebServices.Infrastructure.Settings;

namespace Mmu.Mls.WebServices.DataAccess.DocumentDb.Implementation
{
    public class DocumentService : IDocumentService
    {
        private readonly AppSettings _appSettings;
        private readonly Uri _collectionLink;
        private readonly IDocumentClientSingleton _documentClientSingleton;

        public DocumentService(IAppSettingsService appSettingsService, IDocumentClientSingleton documentCientSingleton)
        {
            _appSettings = appSettingsService.AppSettings;
            _documentClientSingleton = documentCientSingleton;
            _collectionLink = UriFactory.CreateDocumentCollectionUri(_appSettings.DocumentDbDatabaseId, _appSettings.DocumentDbCollectionId);
        }

        public async Task DeleteDocumentAsync(string id)
        {
            var documentUrl = UriFactory.CreateDocumentUri(_appSettings.DocumentDbDatabaseId, _appSettings.DocumentDbCollectionId, id);
            var existingDocument = _documentClientSingleton.Instance.CreateDocumentQuery(_collectionLink).Where(f => f.Id == id).ToList().FirstOrDefault();
            if (existingDocument != null)
            {
                await _documentClientSingleton.Instance.DeleteDocumentAsync(documentUrl);
            }
        }

        public IQueryable<TModel> QueryDocuments<TModel>()
        {
            return _documentClientSingleton.Instance.CreateDocumentQuery<TModel>(_collectionLink);
        }

        public async Task<string> UpsertDocumentAsync<TModel>(TModel model)
        {
            var document = await _documentClientSingleton.Instance.UpsertDocumentAsync(_collectionLink, model);
            return document.Resource.Id;
        }
    }
}