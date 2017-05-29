using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Mmu.Mls.WebServices.Models.Dtos;

namespace Mmu.Mls.WebServices.Logics
{
    public interface IFactsOverviewService
    {
        Task<IReadOnlyCollection<FactOverviewEntry>> LoadOverviewAsync();
    }
}
