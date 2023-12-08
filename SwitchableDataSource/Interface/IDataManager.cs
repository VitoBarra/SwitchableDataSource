namespace SwitchableDataSource.Interface;

public interface IDataManager<T> : IDataReader<T>, IDataSaver<T>
{
}