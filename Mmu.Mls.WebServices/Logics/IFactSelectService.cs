﻿using System.Collections.Generic;
using System.Threading.Tasks;
using Mmu.Mls.WebServices.Models.Dtos;

namespace Mmu.Mls.WebServices.Logics
{
    public interface IFactSelectService
    {
        Task<IReadOnlyCollection<FactSelectEntry>> LoadSelectEntriesAsync();
    }
}