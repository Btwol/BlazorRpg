using BlazorRpg.Server.Controllers.BaseController;
using BlazorRpg.Server.Data;
using BlazorRpg.Server.Services.TestModelService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorRpg.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestModelController : BaseController<TestModel>
    {
        public TestModelController(ITestModelService service) : base(service)
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
        public override Task<IActionResult> Create(TestModel model)
        {
            return base.Create(model);
        }

        [HttpPut("{id}")]
        public override Task<IActionResult> Edit(TestModel model)
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
