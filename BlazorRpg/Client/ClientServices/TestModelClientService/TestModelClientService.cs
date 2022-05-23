
namespace BlazorRpg.Client.ClientServices.TestModelClientService
{
    public class TestModelClientService : ITestModelClientService
    {
        private readonly HttpClient _httpClient;
        public List<TestModel> TestModels { get; set; }
        public TestModelClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<TestModel> GetById(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<TestModel>($"api/testmodel/{Id}");
            if (result != null) return result;
            throw new Exception("Test Model not found.");
        }

        public async Task GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<TestModel>>("api/testmodel");
            if (result != null) TestModels = result;
        }

        public async Task Create(TestModel model)
        {
            var result = await _httpClient.PostAsJsonAsync("api/testmodel", model);
        }

        public async Task Edit(TestModel model)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/testmodel/{model.Id}", model);
        }

        public async Task Delete(int Id)
        {
            var result = await _httpClient.DeleteAsync($"api/testmodel/{Id}");
            await GetAll();
        }
    }
}
