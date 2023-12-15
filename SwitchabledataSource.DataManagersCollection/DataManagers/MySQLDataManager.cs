using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataManagerCollection.DataManagers;

public class MySQLDataManager<T> : IDataManager<T>
{
    string _connectionString;

    public MySQLDataManager(string connectionString)
    {
        _connectionString = connectionString;
    }

    public IList<T> ReadList()
    {
        throw new NotImplementedException();
    }

    public T ReadObject()
    {
        throw new NotImplementedException();
    }

    public void Save(IList<T> dataList)
    {
        throw new NotImplementedException();
    }

    public void Release()
    {
        throw new NotImplementedException();
    }
}