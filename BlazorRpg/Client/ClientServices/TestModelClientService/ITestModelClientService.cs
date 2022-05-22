namespace BlazorRpg.Client.ClientServices.TestModelClientService
{
    public interface ITestModelClientService : IBaseClientService<TestModel>
    {
        List<TestModel> TestModels { get; set; }
    }
}
