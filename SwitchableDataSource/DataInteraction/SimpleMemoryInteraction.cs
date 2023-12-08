using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataInteraction;

public class SimpleMemoryInteraction<T> : AbstractMemoryInteraction<T>
{
    public SimpleMemoryInteraction(IDataManager<T> dataManager, bool LazyRead = true, Type listType = null) : base(
        dataManager, listType)
    {
        if (!LazyRead) Initialize();
    }

    public override void AddOrModify(T? e)
    {
        Initialize();
        Data.ToList().RemoveAll(x => x != null && x.Equals(e));
        Data.Add(e);
        DirtBit = true;
    }


    public override void Save()
    {
        Initialize();

        if (!WriteAllowed) return;
        DataManager.Save(Data);
        DirtBit = false;
    }


    public override T? ReadObject()
    {
        return Data[0];
    }

    public override IList<T?> ReadList()
    {
        Initialize();
        return Data;
    }
}