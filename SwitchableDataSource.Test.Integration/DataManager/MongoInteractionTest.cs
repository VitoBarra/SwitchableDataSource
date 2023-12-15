using SwitchableDataSource.DataManagerCollection.DataManagers;
using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Test.Integration.Implementation;

[TestFixture(Category = "Integration")]
public class MongoInteractionTest:AbstractDataManagerTest
{

    protected override  IDataManager<T> GetDataManager<T>()
    {
        return new MongoDBDataManager<T>("");
    }

    protected override void ClearFunction()
    {
    }

}