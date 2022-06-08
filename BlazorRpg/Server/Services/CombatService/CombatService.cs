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
            var firstCombatant = (await _repository.FindAll()).MaxBy(x => x.Initiative);
            firstCombatant.Turn = true;
            //firstCombatant.Combatant = null;
            await _repository.Edit(firstCombatant);
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

                //Ends current combatants turn
                currentCombatant.Turn = false;
                await _repository.Edit(currentCombatant);

                //Set next combatant in initiative queue to active
                do
                {
                    if (currentCombatants[currentCombatants.Count() - 1] == currentCombatant)
                    {
                        currentCombatant = currentCombatants[0];
                        if (currentCombatant.Status) currentCombatant.Turn = true;
                        await _repository.Edit(currentCombatant);
                    }
                    else
                    {
                        currentCombatant = currentCombatants[currentCombatants.IndexOf(currentCombatant) + 1];
                        if(currentCombatant.Status) currentCombatant.Turn = true;
                        await _repository.Edit(currentCombatant);
                    }
                } while(!currentCombatant.Status);
            }
            currentCombatants = await LoadQueue();
            if (!currentCombatants.Where(c => c.IsPlayer).Any(c => c.Status) || !currentCombatants.Where(c => !c.IsPlayer).Any(c => c.Status)) ActiveCombat = false;
            return currentCombatants.ToList();
        }

        public async Task EndCombat()
        {
            List<CurrentCombatant> currentCombatants = await LoadQueue();
            await GrantXP(currentCombatants);
            foreach(CurrentCombatant currentCombatant in currentCombatants)
            {
                await _repository.Delete(currentCombatant);
            }
        }

        private async Task GrantXP(List<CurrentCombatant> currentCombatants)
        {
            foreach(CurrentCombatant currentCombatant in currentCombatants)
            {
                if(currentCombatant.Status)
                {
                    if(currentCombatant.IsPlayer)
                    {
                        foreach (CurrentCombatant defeatedCombatant in currentCombatants) 
                            if (!defeatedCombatant.IsPlayer) currentCombatant.Combatant.Exp += defeatedCombatant.Combatant.Level * 10;
                    }
                    else if (!currentCombatant.IsPlayer)
                    {
                        foreach (CurrentCombatant defeatedCombatant in currentCombatants)
                            if (defeatedCombatant.IsPlayer) currentCombatant.Combatant.Exp += defeatedCombatant.Combatant.Level * 10;
                    }
                    await _characterService.Edit((Character)currentCombatant.Combatant);
                }
            }
        }

        private async Task<CurrentCombatant> Act(CurrentCombatant Actor, CombatAction combatAction)
        {
            //Combatant Actor = await _characterService.GetById(combatAction.ActorId);
            CurrentCombatant Target = (await LoadQueue()).Where(c => c.Id == combatAction.TargetId).FirstOrDefault();
            Target.CurrentHP -= Actor.Combatant.Str*20;
            if (Target.CurrentHP <= 0) Target.Status = false;
            await _repository.Edit(Target);
            return Target;
        }
    }
}
