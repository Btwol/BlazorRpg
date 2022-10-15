using BlazorRpg.Server.Controllers.BaseController;
using BlazorRpg.Server.Services.ResourceProfileService;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRpg.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResourceProfileController : BaseController<ResourceProfile>
    {
        public ResourceProfileController(IResourceProfileService service) : base(service)
        {

        }

        //[HttpGet]
        //public override Task<IActionResult> GetAll()
        //{
        //    return base.GetAll();
        //}

        [HttpGet("{id}")]
        public override Task<IActionResult> GetById(int id)
        {
            return base.GetById(id);
        }

        //[HttpPost]
        //public override Task<IActionResult> Create(ResourceProfile model)
        //{
        //    return base.Create(model);
        //}

        //[HttpPut("{id}")]
        //public override Task<IActionResult> Edit(ResourceProfile model)
        //{
        //    return base.Edit(model);
        //}

        //[HttpDelete("{id}")]
        //public override Task<IActionResult> Delete(int id)
        //{
        //    return base.Delete(id);
        //}
    }
}
