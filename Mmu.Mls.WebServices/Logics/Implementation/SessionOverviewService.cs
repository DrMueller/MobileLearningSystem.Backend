using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Mmu.Mls.WebServices.DataAccess.Repositories;
using Mmu.Mls.WebServices.Models.Dtos;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.Logics.Implementation
{
    public class SessionOverviewService : ISessionOverviewService
    {
        private readonly IMapper _mapper;
        private readonly IRepositoryFactory _repositoryFactory;

        public SessionOverviewService(IRepositoryFactory repositoryFactory, IMapper mapper)
        {
            _repositoryFactory = repositoryFactory;
            _mapper = mapper;
        }

        public async Task<IReadOnlyCollection<SessionOverviewEntry>> LoadOverviewAsync()
        {
            var sessionRepo = _repositoryFactory.CreateRepository<Session>();
            var allSessions = await sessionRepo.GetAllAsync();

            var result = _mapper.Map<List<SessionOverviewEntry>>(allSessions);
            return result;
        }
    }
}