using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Implementation;

public class DataIOManager<T>
{
    protected IDataReader<T> reader;
    protected IDataSaver<T> Saver;
    protected readonly object ReaderLock = new();
    protected readonly object SaverLock = new();

    public DataIOManager(IDataSaver<T> _saver, IDataReader<T> _reader)
    {
        reader = _reader;
        Saver = _saver;
    }

    public void SetSaver(IDataSaver<T> _saver)
    {
        lock (SaverLock)
        {
            Saver = _saver;
        }
    }

    public void SetReader(IDataReader<T> _reader)
    {
        lock (ReaderLock)
        {
            reader = _reader;
        }
    }

    public void Save(IList<T> e)
    {
        lock (SaverLock)
        {
            Saver?.FlushData(e);
        }
    }

    public IList<T> ReadList()
    {
        IList<T> list = null;
        lock (ReaderLock)
        {
            if (reader != null)
                list = reader.ReadDataList();
        }

        return list;
    }
}