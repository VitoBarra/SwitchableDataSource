using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataManager;

public class SimpleDataManager<T> : AbstractDataManager<T>
{
    public SimpleDataManager(IDataSaver<T> saver, IDataReader<T> reader) : base(saver, reader)
    {
    }
}