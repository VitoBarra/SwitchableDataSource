using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataManager;

public abstract class AbstractDataManager<T> : IDataManager<T>
{
    protected IDataReader<T> Reader;
    protected IDataSaver<T> Saver;
    protected readonly object ReaderLock = new();
    protected readonly object SaverLock = new();

    protected AbstractDataManager(IDataSaver<T> saver, IDataReader<T> reader)
    {
        Saver = saver;
        Reader = reader;
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
            Reader = _reader;
        }
    }


    public virtual void Save(IList<T> e)
    {
        lock (SaverLock)
        {
            Saver?.Save(e);
        }
    }

    public virtual void Append(T e)
    {
        if (e == null) return;
        lock (SaverLock)
        {
            Saver.Append(e);
        }
    }

    public virtual void Append(IList<T> e)
    {
        lock (SaverLock)
        {
            Saver.Append(e);
        }
    }

    public virtual IList<T> ReadList()
    {
        IList<T> list = null;
        lock (ReaderLock)
        {
            list = Reader.ReadList();
        }

        return list;
    }

    public virtual T ReadObject()
    {
        T obj = default;
        lock (ReaderLock)
        {
            obj = Reader.ReadObject();
        }

        return obj;
    }
}