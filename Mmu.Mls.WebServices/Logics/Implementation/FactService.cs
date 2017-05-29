using System.Threading.Tasks;
using Mmu.Mls.WebServices.DataAccess.Repositories;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.Logics.Implementation
{
    public class FactService : IFactService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public FactService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task DeleteFactAsync(string factId)
        {
            var factRepo = _repositoryFactory.CreateRepository<Fact>();
            await factRepo.DeleteAsync(factId);
        }

        public async Task<Fact> LoadFactAsync(string factId)
        {
            var factRepo = _repositoryFactory.CreateRepository<Fact>();
            var result = await factRepo.LoadByIdAsync(factId);

            return result;
        }

        public async Task<Fact> SaveFactAsync(Fact fact)
        {
            var factRepo = _repositoryFactory.CreateRepository<Fact>();
            var result = await factRepo.SaveAsync(fact);

            return result;
        }
    }
}