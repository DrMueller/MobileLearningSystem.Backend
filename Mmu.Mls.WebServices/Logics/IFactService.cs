using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.Logics
{
    public interface IFactService
    {
        Task DeleteFactAsync(string factId);

        Task<Fact> LoadFactAsync(string factId);

        Task<IReadOnlyCollection<Fact>> GetFactsAsync(string[] factIds);

        Task<Fact> SaveFactAsync(Fact fact);
    }
}