using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataInteraction;

// This has to be REDONE, This class is intended to do operation directly on the source and so slower but using minimal memory
// at this moment it is just slower and not using minimal memory
public class DirectDataInteraction<T> : AbstractDataInteraction<T>
{
    public DirectDataInteraction(IDataManager<T> dataManager, Type? listType = null) : base(dataManager, listType)
    {
    }

    public override void SaveToSource()
    {
        base.SaveToSource();
        Data.Clear();
    }


    public override bool DeleteIfExists(Func<T, bool> filterFunction)
    {
        ReadFromSource();
        var deletedSomething = base.DeleteIfExists(filterFunction);
        if (deletedSomething)
            SaveToSource();
        return deletedSomething;
    }

    public override void AddOrModify(IList<T> elements)
    {
        ReadFromSource();
        base.AddOrModify(elements);
        SaveToSource();
    }

    public override void AddOrModify(T element)
    {
        ReadFromSource();
        base.AddOrModify(element);
        SaveToSource();
    }

    public override void DeleteAll(Predicate<T> FilterFunction)
    {
        ReadFromSource();
        base.DeleteAll(FilterFunction);
        SaveToSource();
    }

    public override T? GetObjectWhere(Func<T, bool> getFunction)
    {
        ReadFromSource();
        return base.GetObjectWhere(getFunction);
    }
}