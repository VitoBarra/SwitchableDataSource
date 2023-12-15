using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataManagerCollection.DataManagers;

public class MongoDBDataManager<T>:IDataManager<T>
{
    string _connectionString;

    public MongoDBDataManager(string connectionString)
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