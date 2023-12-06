

namespace SwitchableDataSource.Interface;

public interface IMemoryObjectStrategy<T> :  IMemoryStrategy<T>
{
    T? ReadObject();
}