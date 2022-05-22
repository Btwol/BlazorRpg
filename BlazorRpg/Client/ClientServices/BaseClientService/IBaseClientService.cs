namespace BlazorRpg.Client.ClientServices
{
    public interface IBaseClientService<T> where T : IBaseModel
    {
        Task GetAll();
        Task<T> GetById(int id);
        Task Create(T model);
        Task Edit(T model);
        Task Delete(int id);
    }
}
