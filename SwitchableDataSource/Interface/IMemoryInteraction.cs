

namespace SwitchableDataSource.Interface;

public interface IMemoryInteraction<T>
{
    void AddOrModify(T? e);

    void Save();
    void Append();

    void SaveAndClose();

    T? ReadObject();

    IList<T?> ReadList();
}