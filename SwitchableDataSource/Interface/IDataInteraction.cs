

namespace SwitchableDataSource.Interface;

public interface IDataInteraction<T>
{
    void SaveToSource();
    IList<T> ReadFromSource();
    void SaveAndClose();



    int Count { get; }
    T? GetObjectWhere(Func<T, bool> getFunction);
    void AddOrModify(T element);
    void AddOrModify(IList<T> elements);
    bool DeleteIfExists(Func<T, bool> getFunction);
    void DeleteAll(Predicate<T> FilterFunction);
    IList<T> CreateListInstance();




    void SetSaver(IDataSaver<T> saver);

    void SetReader(IDataReader<T> reader);

    void SetDataManager(IDataManager<T> dataManager);

}