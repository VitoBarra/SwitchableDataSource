using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Test.MemorizationStrategy;

public class FakeDataManager<T> : IDataManager<T>
{
    private IList<T> Data = new List<T>();

    public IList<T> ReadList()
    {
        return Data;
    }

    public T ReadObject()
    {
        return Data[0];
    }

    public void Save(IList<T> dataList)
    {
        Data = dataList;
    }


    public void Append(T data)
    {
        Data.Add(data);
    }

    public void Release()
    {
        return;
    }
}