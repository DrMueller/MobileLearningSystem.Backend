using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Mmu.Mls.WebServices.DataAccess.DocumentDb;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.DataAccess.Repositories.Implementation
{
    public class Repository<TModel> : IRepository<TModel>
        where TModel : Entity, new()
    {
        private readonly IDocumentService _documentClientService;

        private static string ModelTypeName => typeof(TModel).Name;

        public Repository(IDocumentService documentClientService)
        {
            _documentClientService = documentClientService;
        }

        public async Task DeleteAsync(string id)
        {
            await _documentClientService.DeleteDocumentAsync(id);
        }

        public async Task<IReadOnlyCollection<TModel>> GetAllAsync()
        {
            var result = await GetAsync(f => true);
            return result;
        }

        public async Task<IReadOnlyCollection<TModel>> GetAsync(Expression<Func<TModel, bool>> predicate)
        {
            return await Task.Run<IReadOnlyCollection<TModel>>(
                () =>
                    {
                        var qry = _documentClientService.QueryDocuments<TModel>().Where(predicate);
                        qry = qry.Where(f => f.TypeName == ModelTypeName);
                        var result = qry.ToList();
                        return result;
                    });
        }

        public async Task<TModel> LoadByIdAsync(string id)
        {
            var models = await GetAsync(f => f.Id == id);
            var result = models.FirstOrDefault();

            return result;
        }

        public async Task<TModel> SaveAsync(TModel model)
        {
            var id = await _documentClientService.UpsertDocumentAsync(model);
            var result = await LoadByIdAsync(id);

            return result;
        }
    }
}