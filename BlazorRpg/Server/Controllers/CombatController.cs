using BlazorRpg.Server.Controllers.BaseController;
using BlazorRpg.Server.Services.CombatService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRpg.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CombatController : ControllerBase
    {
        private readonly ICombatService _service;

        public CombatController(ICombatService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var models = await _service.GetAll();
            return Ok(models);
        }


        [HttpPost("initiate")]
        public async Task<IActionResult> InitiateCombat(List<CurrentCombatant> currentCombatants)
        {
            await _service.InitiateCombat(currentCombatants);
            return Ok();
        }

        [HttpPost("nextturn")]
        public async Task<IActionResult> NextTurn(CombatAction combatAction)
        {
            await _service.NextTurn(combatAction);
            return Ok();
        }
    }
}
