using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataManagerCollection.DataManagers;

public class CsvDataManager<T>:IDataManager<T>
{
    string FileName;
    public CsvDataManager(string filename)
    {
        FileName = filename;
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