using SwitchableDataSource.Interface;

namespace SwitchableDataSource.MemoryInteraction;

public abstract class AbstractMemoryInteraction<T> : IMemoryInteraction<T>
{
    protected bool IsInitialized = false;
    protected bool DirtBit = false;
    protected virtual bool WriteAllowed => DirtBit && Data.Count != 0;

    protected IDataManager<T?> DataManager;
    protected IList<T> Data;
    protected readonly Type ListType;

    public AbstractMemoryInteraction(IDataManager<T?> dataManager, Type listType = null)
    {
        if (listType != null)
        {
            if (!typeof(IList<T>).IsAssignableFrom(listType))
                throw new ArgumentException("listType must implement IList<T>", nameof(listType));

            ListType = listType;
        }
        else
        {
            ListType = typeof(List<T>);
        }

        DataManager = dataManager;
    }


    protected void Initialize()
    {
        if (IsInitialized) return;
        InitializationMethod();
        IsInitialized = true;
    }

    protected virtual void InitializationMethod()
    {
        Data = (IList<T?>)Activator.CreateInstance(ListType);
        var data = DataManager.ReadList() ;

        if (data == null) return;

        foreach (var d in data)
            Data?.Add(d); 
    }

    public virtual T? ReadObject()
    {
        return DataManager.ReadObject();
    }

    public virtual IList<T?> ReadList()
    {
        return DataManager.ReadList();
    }

    public abstract void AddOrModify(T? e);
    public abstract void Save();

    public virtual void Append()
    {
        throw new NotSupportedException();
    }

    public virtual void SaveAndClose()
    {
        Save();
    }
}