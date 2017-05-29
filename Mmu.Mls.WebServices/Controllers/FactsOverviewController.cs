using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Mls.WebServices.Logics;

namespace Mmu.Mls.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class FactsOverviewController : Controller
    {
        private readonly IFactsOverviewService _factsOverviewService;

        public FactsOverviewController(IFactsOverviewService factsOverviewService)
        {
            _factsOverviewService = factsOverviewService;
        }

        [HttpGet]
        public async Task<IActionResult> LoadOverviewAsync()
        {
            var result = await _factsOverviewService.LoadOverviewAsync();
            return Ok(result);
        }
    }
}