using Microsoft.Azure.Documents.Client;

namespace Mmu.Mls.WebServices.DataAccess.DocumentDb.Handlers
{
    public interface IDocumentClientSingleton
    {
        DocumentClient Instance { get; }
    }
}