//using System.Net.Http.Json;
//
//namespace BlazorRpg.Client.ClientServices.BaseClientService
//{
//    public class BaseClientService<T> : IBaseClientService<T> where T : IBaseModel
//    {
//        private readonly HttpClient _httpClient;
//        private readonly string controllerName;
//        public List<T> Models { get; set; }

//        public BaseClientService(HttpClient httpClient, string controllerName, List<T> Models)
//        {
//            _httpClient = httpClient;
//            this.controllerName = controllerName;
//            this.Models = Models;
//        }

//        public virtual async Task<T> GetById(int Id)
//        {
//            var result = await _httpClient.GetFromJsonAsync<T>($"api/{controllerName}/{Id}");
//            if (result != null) return result;
//            throw new Exception($"Model not found.");
//        }

//        public virtual async Task GetAll()
//        {
//            var result = await _httpClient.GetFromJsonAsync<List<T>>($"api/{controllerName}");
//            if (result != null) Models = result;
//        }

//        public virtual async Task Create(T model)
//        {
//            var result = await _httpClient.PostAsJsonAsync($"api/{controllerName}", model);
//        }

//        public virtual async Task Edit(T model)
//        {
//            var result = await _httpClient.PutAsJsonAsync($"api/{controllerName}/{model.Id}", model);
//        }

//        public virtual async Task Delete(int Id)
//        {
//            var result = await _httpClient.DeleteAsync($"api/{controllerName}/{Id}");
//            await GetAll();
//        }
//    }
//}
