using SwitchableDataSource.DataManagers;
using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Builder;

public class DataManagerBuilder<T>
{
    IDataManager<T>? DataManager;
    IDataReader<T> Reader = new DefaultReader<T>();
    IDataSaver<T> Saver = new DefaultSaver<T>();

    public DataManagerBuilder<T> SetSaver(IDataSaver<T> saver)
    {
            Saver = saver;
            return this;
    }

    public DataManagerBuilder<T> SetReader(IDataReader<T> reader)
    {
            Reader = reader;
            return this;
    }

    public DataManagerBuilder<T> SetDataManager(IDataManager<T> dataManager)
    {
            DataManager = dataManager;
            Reader = dataManager;
            Saver = dataManager;
            return this;
    }


    public IDataManager<T> Build()
    {
        return new MixingDataManager<T>(Saver, Reader,DataManager);
    }

}


public class DefaultReader<T> : IDataReader<T>
{
    public IList<T> ReadList()
    {
        throw new NotSupportedException();
    }

    public T ReadObject()
    {
        throw new NotSupportedException();
    }
}

public class DefaultSaver<T> : IDataSaver<T>
{
    public void Save(IList<T> dataList)
    {
        throw new NotSupportedException();
    }

    public void Append(IList<T> dataList)
    {
        throw new NotSupportedException();
    }

    public void Append(T data)
    {
        throw new NotSupportedException();
    }
}