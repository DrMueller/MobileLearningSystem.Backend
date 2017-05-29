using System.Linq;
using System.Threading.Tasks;

namespace Mmu.Mls.WebServices.DataAccess.DocumentDb
{
    public interface IDocumentService
    {
        Task DeleteDocumentAsync(string id);

        IQueryable<TModel> QueryDocuments<TModel>();

        Task<string> UpsertDocumentAsync<TModel>(TModel model);
    }
}