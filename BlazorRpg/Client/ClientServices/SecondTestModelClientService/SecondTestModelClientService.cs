
namespace BlazorRpg.Client.ClientServices.SecondTestModelClientService
{
    public class SecondTestModelClientService : ISecondTestModelClientService
    {
        private readonly HttpClient _httpClient;
        public List<SecondTestModel> SecondTestModels { get; set; }

        public SecondTestModelClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<SecondTestModel> GetById(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<SecondTestModel>($"api/secondtestmodel/{Id}");
            if (result != null) return result;
            throw new Exception("Second Test Model not found.");
        }

        public async Task GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<SecondTestModel>>("api/secondtestmodel");
            if (result != null) SecondTestModels = result;
        }

        public async Task Create(SecondTestModel model)
        {
            var result = await _httpClient.PostAsJsonAsync("api/secondtestmodel", model);
        }

        public async Task Edit(SecondTestModel model)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/secondtestmodel/{model.Id}", model);
        }

        public async Task Delete(int Id)
        {
            var result = await _httpClient.DeleteAsync($"api/secondtestmodel/{Id}");
            await GetAll();
        }
    }
}
