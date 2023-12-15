using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataInteraction.Decorator;

public class DataInteractionDecorator<T> : IDataInteraction<T>
{
    protected IDataInteraction<T> DataInteraction;
    public int Count => DataInteraction.Count;

    protected virtual bool WriteAllowed => DataInteraction.Count != 0;




    protected DataInteractionDecorator(IDataInteraction<T> dataInteraction)
    {
        DataInteraction = dataInteraction;
    }


    public virtual void AddOrModify(T element)
    {
        DataInteraction.AddOrModify(element);
    }

    public void AddOrModify(IList<T> elements)
    {
        DataInteraction.AddOrModify(elements);
    }

    public bool DeleteIfExists(Func<T, bool> getFunction)
    {
        return DataInteraction.DeleteIfExists(getFunction);
    }

    public void DeleteAll(Predicate<T> FilterFunction)
    {
        DataInteraction.DeleteAll(FilterFunction);
    }

    public virtual void SaveToSource()
    {
        DataInteraction.SaveToSource();
    }



    public virtual void SaveAndClose()
    {
        DataInteraction.SaveAndClose();

    }

    public virtual T? GetObjectWhere(Func<T, bool> getFunction)
    {
        return DataInteraction.GetObjectWhere(getFunction);
    }

    public virtual IList<T> ReadFromSource()
    {
        return DataInteraction.ReadFromSource();
    }

    public void SetSaver(IDataSaver<T> saver)
    {
        DataInteraction.SetSaver(saver);
    }

    public void SetReader(IDataReader<T> reader)
    {
        DataInteraction.SetReader(reader);
    }

    public void SetDataManager(IDataManager<T> reader)
    {
        DataInteraction.SetDataManager(reader);
    }

    public IList<T> CreateListInstance()
    {
        return DataInteraction.CreateListInstance();
    }
}