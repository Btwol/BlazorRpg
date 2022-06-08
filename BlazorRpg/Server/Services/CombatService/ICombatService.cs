namespace BlazorRpg.Server.Services.CombatService
{
    public interface ICombatService : IBaseService<CurrentCombatant>
    {
        public bool ActiveCombat { get; set; }
        //public Queue<CurrentCombatant> combatantQueue { get; set; }
        public Task InitiateCombat(List<CurrentCombatant> currentCombatants);
        public Task EndCombat();
        public Task<List<CurrentCombatant>> NextTurn(CombatAction combatAction);
    }
}
