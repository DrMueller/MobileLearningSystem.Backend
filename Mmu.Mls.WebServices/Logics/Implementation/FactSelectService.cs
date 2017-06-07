using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Mls.WebServices.DataAccess.Repositories;
using Mmu.Mls.WebServices.Models.Dtos;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.Logics.Implementation
{
    public class FactSelectService : IFactSelectService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryFactory _repositoryFactory;

        public FactSelectService(IRepositoryFactory repositoryFactory, IMapper mapper)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<FactSelectEntry>> LoadSelectEntriesAsync()
        {
            var factRepo = _repositoryFactory.CreateRepository<Fact>();
            var allFacts = await factRepo.GetAllAsync();

            var result = _mapper.Map<List<FactSelectEntry>>(allFacts);
            return result;
        }
    }
}