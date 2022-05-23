using BlazorRpg.Server.Services.CharacterService;

namespace BlazorRpg.Server.Services.CombatService
{
    public class CombatService : ICombatService
    {
        public Queue<CurrentCombatant> combatantQueue { get; set; }
        public bool ActiveCombat { get; set; } = true;
        private readonly ICharacterService _characterService;
        private readonly Random random = new Random();

        public CombatService(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        public async Task InitiateEncounter(List<int> player, List<int> npc)
        {
            Dictionary<int, CurrentCombatant> combatantInitiativeRoll = new Dictionary<int, CurrentCombatant>();   
            foreach (int combatantId in player)
            {
                Combatant combatant = await _characterService.GetById(combatantId);
                if (combatant != null) combatantInitiativeRoll.Add(random.Next(100), new CurrentCombatant { Combatant = combatant, IsPlayer = true, Status = true});
            }
            foreach (int combatantId in npc)
            {
                Combatant combatant = await _characterService.GetById(combatantId);
                if (combatant != null) combatantInitiativeRoll.Add(random.Next(100), new CurrentCombatant { Combatant = combatant, IsPlayer = false, Status = true });
            }

            combatantInitiativeRoll.OrderBy(c => c.Key);
            foreach(KeyValuePair<int, CurrentCombatant> combatant in combatantInitiativeRoll) combatantQueue.Enqueue(combatant.Value);
        }

        public async Task NextTurn(int? targetId)
        {
            if (ActiveCombat)
            {
                CurrentCombatant currentCombatant = combatantQueue.Dequeue();
                if (currentCombatant.IsPlayer)
                {
                    await Attack(currentCombatant.Combatant, await _characterService.GetById((int)targetId));
                }
                else
                {
                    int playerCount = combatantQueue.Where(c => c.IsPlayer).Count();
                    List<CurrentCombatant> Targets = combatantQueue.Where(c => c.IsPlayer && c.Status).ToList();
                    await Attack(currentCombatant.Combatant, Targets[random.Next(Targets.Count)].Combatant);
                }
            }
            if(combatantQueue.Where(c => c.IsPlayer && !c.Status).Count()<1 || combatantQueue.Where(c => !c.IsPlayer && !c.Status).Count() < 1) ActiveCombat = false;
        }

        public async Task Attack(Combatant attacker, Combatant defender)
        {
            defender.HP -= attacker.Str;
        }
    }
}
