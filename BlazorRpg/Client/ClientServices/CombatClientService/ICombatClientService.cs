namespace BlazorRpg.Client.ClientServices.CombatClientService
{
    public interface ICombatClientService
    {
        public List<CurrentCombatant> currentCombatants { get; set; }
        public Task GetCurrentCombatants();
        public Task InitiateCombat(List<CurrentCombatant> currentCombatants);
        public Task EndCombat();
        public Task NextTurn(CombatAction combatAction);
    }
}
