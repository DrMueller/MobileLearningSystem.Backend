using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Mls.WebServices.Logics;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class SessionController : Controller
    {
        private readonly IFactService _factService;
        private readonly ISessionService _sessionService;

        public SessionController(ISessionService sessionService, IFactService factService)
        {
            _sessionService = sessionService;
            _factService = factService;
        }

        [HttpDelete("{sessionId}")]
        public async Task<IActionResult> DeleteSessionAsync(string sessionId)
        {
            await _sessionService.DeleteSessionAsync(sessionId);
            return Ok();
        }

        [HttpGet("{sessionId}")]
        public async Task<IActionResult> GetSessionAsync(string sessionId)
        {
            var result = await _sessionService.LoadSessionAsync(sessionId);
            return Ok(result);
        }

        [HttpGet("{sessionId}/facts")]
        public async Task<IActionResult> LoadFactsBySessionAsync(string sessionId)
        {
            var session = await _sessionService.LoadSessionAsync(sessionId);
            var factIds = session.SessionFacts.Select(f => f.FactId).ToArray();
            var result = await _factService.GetFactsAsync(factIds);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> SaveSessionAsync([FromBody] Session session)
        {
            var result = await _sessionService.SaveSessionAsync(session);
            return Ok(result);
        }
    }
}