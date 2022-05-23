using BlazorRpg.Server.Repositories.CharacterRepository;

namespace BlazorRpg.Server.Services.CharacterService
{
    public class CharacterService : BaseService<Character>, ICharacterService
    {
        public CharacterService(ICharacterRepository repository) : base(repository)
        {

        }
    }
}
