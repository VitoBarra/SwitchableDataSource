namespace SwitchableDataSource.Interface;

public interface IDataSaver<T>
{
    void FlushData(IList<T> DataList);
}