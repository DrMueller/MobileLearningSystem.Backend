using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Mls.WebServices.Logics;

namespace Mmu.Mls.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class FactSelectController : Controller
    {
        private readonly IFactSelectService _factSelectService;

        public FactSelectController(IFactSelectService factSelectService)
        {
            _factSelectService = factSelectService;
        }

        [HttpGet]
        public async Task<IActionResult> LoadSelectsAsync()
        {
            var result = await _factSelectService.LoadSelectEntriesAsync();
            return Ok(result);
        }
    }
}