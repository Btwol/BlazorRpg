
namespace BlazorRpg.Server.Services.SecondTestModelService
{
    public class SecondTestModelService : BaseService<SecondTestModel>, ISecondTestModelService
    {
        public SecondTestModelService(IBaseRepository<SecondTestModel> repository) : base(repository)
        {

        }

    }
}
