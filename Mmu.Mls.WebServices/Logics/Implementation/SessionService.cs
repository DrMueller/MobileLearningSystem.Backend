using System.Threading.Tasks;
using Mmu.Mls.WebServices.DataAccess.Repositories;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.Logics.Implementation
{
    public class SessionService : ISessionService
    {
        private readonly IRepositoryFactory _repositoryFactory;

        public SessionService(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }

        public async Task DeleteSessionAsync(string sessionId)
        {
            var sessionRepo = _repositoryFactory.CreateRepository<Session>();
            await sessionRepo.DeleteAsync(sessionId);
        }

        public async Task<Session> LoadSessionAsync(string sessionId)
        {
            var sessionRepo = _repositoryFactory.CreateRepository<Session>();
            var result = await sessionRepo.LoadByIdAsync(sessionId);
            return result;
        }

        public async Task<Session> SaveSessionAsync(Session session)
        {
            var sessionRepo = _repositoryFactory.CreateRepository<Session>();
            var result = await sessionRepo.SaveAsync(session);
            return result;
        }
    }
}