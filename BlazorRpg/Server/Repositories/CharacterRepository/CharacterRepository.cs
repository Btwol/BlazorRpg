namespace BlazorRpg.Server.Repositories.CharacterRepository
{
    public class CharacterRepository : BaseRepository<Character>, ICharacterRepository
    {
        public CharacterRepository(DataContext _context) : base(_context)
        {

        }


    }
}
