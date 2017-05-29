using System.Threading.Tasks;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.Logics
{
    public interface ISessionService
    {
        Task DeleteSessionAsync(string sessionId);

        Task<Session> LoadSessionAsync(string sessionId);

        Task<Session> SaveSessionAsync(Session session);
    }
}