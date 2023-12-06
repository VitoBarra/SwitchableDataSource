namespace SwitchableDataSource.Interface;

public interface IMemoryListStrategy<T> : IMemoryStrategy<T>
{
    IList<T> ReadList();
}