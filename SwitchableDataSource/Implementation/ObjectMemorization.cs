using SwitchableDataSource.Interface;


public class ObjectMemorization<T> : IMemoryObjectStrategy<T>
{

    IMemoryListStrategy<T?> Strategy;


    public ObjectMemorization(IMemoryListStrategy<T?> strategy)
    {
        Strategy = strategy;
    }
    public  T? ReadObject()
    {
        var data = Strategy.ReadList();
        return data.Count > 0 ? data[0] : default;
    }

    public void AddOrModify(T e) {
        Strategy.AddOrModify(e);
    }

    public void Save() {
        Strategy.Save();
    }

    public void SaveAndClose() {
        Strategy.SaveAndClose();
    }
}
