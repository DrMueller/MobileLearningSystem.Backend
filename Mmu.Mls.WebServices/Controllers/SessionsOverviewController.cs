using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Mls.WebServices.Logics;

namespace Mmu.Mls.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class SessionsOverviewController : Controller
    {
        private readonly ISessionOverviewService _sessionsOverviewService;

        public SessionsOverviewController(ISessionOverviewService sessionsOverviewService)
        {
            _sessionsOverviewService = sessionsOverviewService;
        }

        [HttpGet]
        public async Task<IActionResult> LoadOverviewAsync()
        {
            var result = await _sessionsOverviewService.LoadOverviewAsync();
            return Ok(result);
        }
    }
}