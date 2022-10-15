using BlazorRpg.Server.Repositories.ResourceProfileRepository;

namespace BlazorRpg.Server.Services.ResourceProfileService
{
    public class ResourceProfileService : BaseService<ResourceProfile>, IResourceProfileService
    {
        public ResourceProfileService(IResourceProfileRepository repository) : base(repository)
        {

        }
    }
}
