using Microsoft.AspNetCore.Mvc;

namespace BlazorRpg.Server.Controllers.BaseController
{
    public class BaseController<T> : ControllerBase, IBaseController<T> where T : IBaseModel
    {
        protected readonly IBaseService<T> _service;

        public BaseController(IBaseService<T> service)
        {
            _service = service;
        }

        public virtual async Task<IActionResult> GetAll()
        {
            var models = await _service.GetAll();
            return Ok(models);
        }
        
        public virtual async Task<IActionResult> GetById(int id)
        {
            var model = await _service.GetById(id);
            if (model == null) return NotFound("Record not found.");
            return Ok(model);
        }

        public virtual async Task<IActionResult> Create(T model)
        {
            await _service.Create(model);
            return Ok(model);
        }

        public virtual async Task<IActionResult> Edit(T model)
        {
            await _service.Edit(model);
            return Ok(model);
        }

        public virtual async Task<IActionResult> Delete(int id)
        {
            await _service.Delete(id);
            return Ok();
        }
    }
}
