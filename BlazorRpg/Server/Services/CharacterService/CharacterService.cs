using BlazorRpg.Server.Repositories.CharacterRepository;

namespace BlazorRpg.Server.Services.CharacterService
{
    public class CharacterService : BaseService<Character>, ICharacterService
    {
        public CharacterService(ICharacterRepository repository) : base(repository)
        {
            
        }
        public override Task<Character> Create(Character model)
        {
            switch(model.Class)
            {
                case CharacterClass.Barbarian:
                    model.Wis /= 2;
                    model.Int /= 2;
                    model.Vit *= 2;
                    model.Str *= 2;
                    model.Att *= 2;
                    break;
                case CharacterClass.Mage:
                    model.Def /= 2;
                    model.Vit /= 2;
                    model.Int *= 2;
                    model.Wis *= 2;
                    break;
                case CharacterClass.Paladin:
                    model.Agi /= 2;
                    model.Att /= 2;
                    model.Vit *= 2;
                    model.Def *= 2;
                    model.Wis *= 2;
                    model.Luck *= 2;
                    break;
                case CharacterClass.Rouge:
                    model.Vit /= 2;
                    model.Def /= 2;
                    model.Att *= 2;
                    model.Agi *= 2;
                    model.Luck *= 2;
                    break;
                case CharacterClass.Fighter:
                    model.Wis /= 2;
                    model.Def *= 2;
                    model.Str *= 2;
                    model.Att *= 2;
                    break;
            }
            model.HP *= model.Vit;
            model.MP *= model.Int;
            return base.Create(model);
        }
    }
}
