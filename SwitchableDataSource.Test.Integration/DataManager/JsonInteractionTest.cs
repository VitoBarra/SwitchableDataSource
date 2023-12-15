using SwitchableDataSource.DataManagerCollection.DataManagers;
using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Test.Integration.Implementation;

[TestFixture(Category = "Integration")]
public class JsonInteractionTest : AbstractDataManagerTest
{
    private string testFilePath = "test.json";

    protected override IDataManager<T> GetDataManager<T>()
    {
        return new JsonDataManager<T>(testFilePath);
    }

    protected override void ClearFunction()
    {
        if (File.Exists(testFilePath))
        {
            File.Delete(testFilePath);
        }
    }







}

