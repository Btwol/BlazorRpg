
namespace BlazorRpg.Server.Services.BaseService
{
    public interface IBaseService<T> where T : IBaseModel
    {
        public Task<IEnumerable<T>> GetAll();
        public Task<T> GetById(int id);
        public Task<IEnumerable<T>> GetByConditions(Expression<Func<T, bool>> expresion);
        public Task<T> Create(T model);
        public Task Edit(T model);
        public Task Delete(int id);
    }
}
