using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Mmu.Mls.WebServices.Logics;
using Mmu.Mls.WebServices.Models.Entities;

namespace Mmu.Mls.WebServices.Controllers
{
    [Route("api/[controller]")]
    public class FactController : Controller
    {
        private readonly IFactService _factService;

        public FactController(IFactService factService)
        {
            _factService = factService;
        }

        [HttpDelete("{factId}")]
        public async Task<IActionResult> DeleteFactAsync(string factId)
        {
            await _factService.DeleteFactAsync(factId);
            return Ok();
        }

        [HttpGet("{factId}")]
        public async Task<IActionResult> LoadFactAsync(string factId)
        {
            var result = await _factService.LoadFactAsync(factId);
            return Ok(result);
        }

        [HttpPut]
        public async Task<IActionResult> SaveFactASync([FromBody] Fact fact)
        {
            var result = await _factService.SaveFactAsync(fact);
            return Ok(result);
        }
    }
}