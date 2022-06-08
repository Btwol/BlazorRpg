namespace BlazorRpg.Client.ClientServices.CombatClientService
{
    public class CombatClientService : ICombatClientService
    {
        private readonly HttpClient _httpClient;
        public List<CurrentCombatant> currentCombatants { get; set; }

        public CombatClientService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task InitiateCombat(List<CurrentCombatant> currentCombatants)
        {
            await _httpClient.PostAsJsonAsync("api/Combat/initiate", currentCombatants);
            //currentCombatants = await result.Content.ReadFromJsonAsync<List<CurrentCombatant>>();
            await GetCurrentCombatants();
        }

        public async Task EndCombat()
        {
            await _httpClient.PostAsJsonAsync("api/Combat/endcombat", "a");
        }

        public async Task NextTurn(CombatAction combatAction)
        {
            await _httpClient.PostAsJsonAsync("api/Combat/nextturn", combatAction);
            //currentCombatants = await result.Content.ReadFromJsonAsync<List<CurrentCombatant>>();
            await GetCurrentCombatants();
        }

        public async Task GetCurrentCombatants()
        {
            var result = await _httpClient.GetFromJsonAsync<List<CurrentCombatant>>("api/Combat");
            if (result != null) currentCombatants = result;
        }
    }
}
