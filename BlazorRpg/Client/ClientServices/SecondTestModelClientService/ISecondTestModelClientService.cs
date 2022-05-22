namespace BlazorRpg.Client.ClientServices.SecondTestModelClientService
{
    public interface ISecondTestModelClientService : IBaseClientService<SecondTestModel>
    {
        List<SecondTestModel> SecondTestModels { get; set; }
    }
}
