using BlazorRpg.Server.Repositories.CombatRepository;
using BlazorRpg.Server.Repositories.TestModelRepository;
using BlazorRpg.Server.Services.CharacterService;

namespace BlazorRpg.Server.Services.CombatService
{
    public class CombatService : BaseService<CurrentCombatant>, ICombatService
    {
        public bool ActiveCombat { get; set; } = true;
        //public Queue<CurrentCombatant> combatantQueue { get; set; }
        //public List<CurrentCombatant> inactiveCombatants { get; set; }
        private readonly ICharacterService _characterService;
        private readonly Random random = new Random();

        public CombatService(ICombatRepository repository, ICharacterService characterService) : base(repository)
        {
            _characterService = characterService;
        }

        public async Task InitiateCombat(List<CurrentCombatant> currentCombatants)
        {
            //ActiveCombat = true;

            foreach (CurrentCombatant currentCombatant in currentCombatants)
            {
                var character = await _characterService.GetById((int)currentCombatant.CombatantId);
                currentCombatant.Initiative = random.Next(100);
                currentCombatant.CurrentHP = character.HP;
                currentCombatant.EncounterId = 0;                               //later
                await _repository.Create(currentCombatant);
            }
        }

        private async Task<List<CurrentCombatant>> LoadQueue()
        {
            List<CurrentCombatant> currentCombatants = (await base.GetAll()).Where(c => c.EncounterId == 0).ToList();
            return currentCombatants.OrderBy(c => c.Initiative).ThenBy(c => c.CombatantId).ToList();
        }

        public async Task<List<CurrentCombatant>> NextTurn(CombatAction combatAction)
        {
            List<CurrentCombatant> currentCombatants = await LoadQueue();
            if (currentCombatants.Any(c => c.Status))
            {
                CurrentCombatant currentCombatant = currentCombatants.Where(c => c.Id == combatAction.ActorId).FirstOrDefault();
                if (currentCombatant.IsPlayer)
                {
                    if (!currentCombatants.Where(c => c.Id == combatAction.TargetId).FirstOrDefault().Status) return await LoadQueue();
                }
                else
                {
                    List<CurrentCombatant> Targets = currentCombatants.Where(c => c.IsPlayer && c.Status).ToList();
                    combatAction.TargetId = Targets[random.Next(Targets.Count())].Id;
                    
                }
                CurrentCombatant Target = await Act(currentCombatant, combatAction);

                //if (combatantQueue.Where(c => c.IsPlayer && !c.Status).Count() < 1 || combatantQueue.Where(c => !c.IsPlayer && !c.Status).Count() < 1) ActiveCombat = false;
            }
            return currentCombatants.ToList();
        }

        private async Task<CurrentCombatant> Act(CurrentCombatant Actor, CombatAction combatAction)
        {
            //Combatant Actor = await _characterService.GetById(combatAction.ActorId);
            CurrentCombatant Target = (await LoadQueue()).Where(c => c.Id == combatAction.TargetId).FirstOrDefault();
            Target.CurrentHP -= Actor.Combatant.Str;
            if (Target.CurrentHP <= 0) Target.Status = false;
            await _repository.Edit(Target);
            return Target;
        }
    }
}
