using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Mls.WebServices.DataAccess.Repositories;
using Mmu.Mls.WebServices.Models.Dtos;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.Logics.Implementation
{
    public class FactsOverviewService : IFactsOverviewService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryFactory _repositoryFactory;

        public FactsOverviewService(IRepositoryFactory repositoryFactory, IMapper mapper)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<FactOverviewEntry>> LoadOverviewAsync()
        {
            var factRepo = _repositoryFactory.CreateRepository<Fact>();
            var allfacts = await factRepo.LoadAllAsync();
            var result = _mapper.Map<List<FactOverviewEntry>>(allfacts);

            return result;
        }
    }
}