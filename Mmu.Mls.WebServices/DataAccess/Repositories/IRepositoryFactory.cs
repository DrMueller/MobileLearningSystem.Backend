using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.DataAccess.Repositories
{
    public interface IRepositoryFactory
    {
        IRepository<TModel> CreateRepository<TModel>()
            where TModel : Entity, new();
    }
}