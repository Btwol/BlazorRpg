namespace BlazorRpg.Client.ClientServices.CharacterClientService
{
    public class CharacterClientService : ICharacterClientService
    {
        private readonly HttpClient _httpClient;
        public List<Character> Characters { get; set; }

        public CharacterClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Character> GetById(int Id)
        {
            var result = await _httpClient.GetFromJsonAsync<Character>($"api/Character/{Id}");
            if (result != null) return result;
            throw new Exception("Model not found.");
        }

        public async Task GetAll()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Character>>("api/Character");
            if (result != null) Characters = result;
        }

        public async Task Create(Character model)
        {
            var result = await _httpClient.PostAsJsonAsync("api/Character", model);
        }

        public async Task Edit(Character model)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/Character/{model.Id}", model);
        }

        public async Task Delete(int Id)
        {
            var result = await _httpClient.DeleteAsync($"api/Character/{Id}");
            await GetAll();
        }
    }
}
