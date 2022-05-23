using BlazorRpg.Server.Repositories.TestModelRepository;

namespace BlazorRpg.Server.Services.TestModelService
{
    public class TestModelService : BaseService<TestModel>, ITestModelService
    {
        public TestModelService(ITestModelRepository repository) : base(repository)
        {

        }

        public override async Task<TestModel> Create(TestModel model)
        {
            model.SecondTestModel = null;
            return await base.Create(model);
        }

        public override async Task Edit(TestModel model)
        {
            model.SecondTestModel = null;
            await base.Edit(model);
        }
    }
}
