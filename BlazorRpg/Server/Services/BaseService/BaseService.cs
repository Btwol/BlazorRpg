
namespace BlazorRpg.Server.Services.BaseService
{
    public class BaseService<T> : IBaseService<T> where T : IBaseModel
    {
        protected readonly IBaseRepository<T> _repository;

        public BaseService(IBaseRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual async Task<IEnumerable<T>> GetAll()
        {
            return await _repository.FindAll();
        }

        public virtual async Task<T> GetById(int id)
        {
            return (await _repository.FindByConditions(x => x.Id == id)).FirstOrDefault();
        }

        public virtual async Task<IEnumerable<T>> GetByConditions(Expression<Func<T, bool>> expresion)
        {
            return await _repository.FindByConditions(expresion);
        }

        public virtual async Task<T> Create(T model)
        {
            return await _repository.Create(model);
        }

        public virtual async Task Edit(T model)
        {
            await _repository.Edit(model);
        }

        public virtual async Task Delete(int id)
        {
            var model = await GetById(id);
            if (model != null) await _repository.Delete(model);
        }
    }
}
