using SwitchableDataSource.Builder;
using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataInteraction;

public abstract class AbstractDataInteraction<T> : IDataInteraction<T>
{
    private readonly DataManagerBuilder<T> DataManagerBuilder;
    protected IDataManager<T> DataManager;
    protected IList<T> Data;
    private readonly Type ListType;
    protected bool DirtyBit = false;
    public int Count => Data.Count;
    private bool WriteEnable => DirtyBit && Count > 0;

    public AbstractDataInteraction(IDataManager<T> dataManager, Type? listType = null)
    {
        DataManagerBuilder = new DataManagerBuilder<T>();
        DataManagerBuilder.SetDataManager(dataManager);
        ListType = ValidateListType(listType);
        Data = CreateListInstance();
        DataManager = dataManager;
    }


    private Type ValidateListType(Type? listType)
    {
        if (listType == null) return typeof(List<T>);

        if (!typeof(IList<T>).IsAssignableFrom(listType))
            throw new ArgumentException("listType must implement IList<T>", nameof(listType));

        return listType;
    }

    public IList<T> CreateListInstance()
    {
        return (IList<T>?)Activator.CreateInstance(ListType) ?? throw new InvalidOperationException();
    }


    public virtual void SaveToSource()
    {
        if (!WriteEnable) return;
        DataManager.Save(Data);
        DirtyBit = false;
    }

    public virtual IList<T> ReadFromSource()
    {
        SaveToSource();
        Data = DataManager.ReadList();
        return Data;
    }

    public virtual void SaveAndClose()
    {
        SaveToSource();
        DataManager.Release();
    }


    public virtual T? GetObjectWhere(Func<T, bool> getFunction)
    {
        return Data.FirstOrDefault(getFunction);
    }

    public virtual void AddOrModify(T element)
    {
        var foundedElement = GetObjectWhere(x => x != null && x.Equals(element));
        if (foundedElement != null)
            Data.ToList().Remove(foundedElement);

        Data.Add(element);
        DirtyBit = true;
    }

    public virtual void AddOrModify(IList<T> elements)
    {
        foreach (var ele in elements)
            AddOrModify(ele);
    }

    public virtual bool DeleteIfExists(Func<T, bool> FilterFunction)
    {
        var e = GetObjectWhere(x => x != null && x.Equals(FilterFunction));
        return e != null && Data.Remove(e);
    }

    public virtual void DeleteAll(Predicate<T> FilterFunction)
    {
        Data.ToList().RemoveAll(FilterFunction);
    }


    public void SetSaver(IDataSaver<T> saver)
    {
        DataManagerBuilder.SetSaver(saver);
        DataManager = DataManagerBuilder.Build();
    }

    public void SetReader(IDataReader<T> reader)
    {
        DataManagerBuilder.SetReader(reader);
        DataManager = DataManagerBuilder.Build();
    }

    public void SetDataManager(IDataManager<T> dataManager)
    {
        DataManagerBuilder.SetDataManager(dataManager);
        DataManager = DataManagerBuilder.Build();
    }
}