using SwitchableDataSource.DataManagerCollection.DataManagers;
using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Test.Integration.Implementation;

public class MySqlDataManagerTest : AbstractDataManagerTest
{
    protected override IDataManager<T> GetDataManager<T>()
    {
        return new MySQLDataManager<T>("");
    }

    protected override void ClearFunction()
    {
    }
}