using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataInteraction;

public class CachedDataInteraction<T> : AbstractDataInteraction<T>
{
    public CachedDataInteraction(IDataManager<T> dataManager, Type? listType = null) : base(dataManager, listType)
    {
    }






}