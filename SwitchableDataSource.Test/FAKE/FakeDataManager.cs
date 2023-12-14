using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Test.MemorizationStrategy;

public class FakeDataManager<T> : IDataManager<T>
{
    private IList<T> Data;
    public IList<T> ReadList()
    {
        return Data;
    }

    public T ReadObject()
    {
        return Data[0];
    }

    public void Save(IList<T> DataList)
    {
        Data = DataList;
    }

    public void Append(IList<T> DataList)
    {
        Data = DataList;
    }

    public void Append(T _data)
    {
        Data.Add(_data);
    }
}