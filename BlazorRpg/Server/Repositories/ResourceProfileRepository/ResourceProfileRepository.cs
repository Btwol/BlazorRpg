namespace BlazorRpg.Server.Repositories.ResourceProfileRepository
{
    public class ResourceProfileRepository : BaseRepository<ResourceProfile>, IResourceProfileRepository
    {
        public ResourceProfileRepository(DataContext _context) : base(_context)
        {

        }

    }
}