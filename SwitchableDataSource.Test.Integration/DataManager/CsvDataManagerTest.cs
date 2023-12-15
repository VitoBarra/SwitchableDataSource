using SwitchableDataSource.DataManagerCollection.DataManagers;
using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Test.Integration.Implementation;

public class CsvDataManagerTest: AbstractDataManagerTest
{
    protected override IDataManager<T> GetDataManager<T>()
    {
        return new CsvDataManager<T>("FileName");
    }

    protected override void ClearFunction()
    {
    }
}