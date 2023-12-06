

namespace SwitchableDataSource.Interface;

public interface IMemoryStrategy<T>
{
    void AddOrModify(T e);

    void Save();

    void SaveAndClose();
}