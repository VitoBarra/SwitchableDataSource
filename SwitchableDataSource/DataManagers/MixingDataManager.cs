using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataManagers;

public class MixingDataManager<T> : IDataManager<T>
{
    private IDataReader<T> Reader;
    private IDataSaver<T> Saver;
    IDataManager<T>? DataManager;

    public MixingDataManager(IDataSaver<T> saver, IDataReader<T> reader)
    {
        Saver = saver;
        Reader = reader;
    }

    public MixingDataManager(IDataSaver<T> saver, IDataReader<T> reader, IDataManager<T>? dataManager) : this(saver,
        reader)
    {
        DataManager = dataManager;
    }

    public MixingDataManager(IDataManager<T> dataManager) : this(dataManager, dataManager)
    {
        DataManager = dataManager;
    }


    public IList<T> ReadList()
    {
        return Reader.ReadList();
    }

    public T ReadObject()
    {
        return Reader.ReadObject();
    }

    public void Save(IList<T> dataList)
    {
        Saver.Save(dataList);
    }


    public void Release()
    {
        DataManager?.Release();
    }
}