namespace BlazorRpg.Client.ClientServices.CharacterClientService
{
    public interface ICharacterClientService : IBaseClientService<Character>
    {
        List<Character> Characters { get; set; }
    }
}
