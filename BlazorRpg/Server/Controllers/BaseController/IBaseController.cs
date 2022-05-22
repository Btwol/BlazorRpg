using Microsoft.AspNetCore.Mvc;

namespace BlazorRpg.Server.Controllers.BaseController
{
    public interface IBaseController<T>
    {
        public Task<IActionResult> GetAll();
        public Task<IActionResult> GetById(int id);
        public Task<IActionResult> Create(T model);
        public Task<IActionResult> Edit(T model);
        public Task<IActionResult> Delete(int id);
    }
}
