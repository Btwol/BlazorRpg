namespace BlazorRpg.Server.Repositories.CombatRepository
{
    public class CombatRepository : BaseRepository<CurrentCombatant>, ICombatRepository
    {
        public CombatRepository(DataContext _context) : base(_context)
        {

        }

        public override async Task<IEnumerable<CurrentCombatant>> FindAll()
        {
            return await _context.CurrentCombatants.Include(c => c.Combatant).ToListAsync();
        }

        public override async Task<IEnumerable<CurrentCombatant>> FindByConditions(Expression<Func<CurrentCombatant, bool>> expresion)
        {
            return await _context.CurrentCombatants.Where(expresion).Include(c => c.Combatant).ToListAsync();
        }
    }
}
