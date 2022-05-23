using BlazorRpg.Server.Controllers.BaseController;
using BlazorRpg.Server.Services.CharacterService;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRpg.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : BaseController<Character>
    {
        public CharacterController(ICharacterService service) : base(service)
        {

        }

        [HttpGet]
        public override Task<IActionResult> GetAll()
        {
            return base.GetAll();
        }

        [HttpGet("{id}")]
        public override Task<IActionResult> GetById(int id)
        {
            return base.GetById(id);
        }

        [HttpPost]
        public override Task<IActionResult> Create(Character model)
        {
            return base.Create(model);
        }

        [HttpPut("{id}")]
        public override Task<IActionResult> Edit(Character model)
        {
            return base.Edit(model);
        }

        [HttpDelete("{id}")]
        public override Task<IActionResult> Delete(int id)
        {
            return base.Delete(id);
        }
    }
}
