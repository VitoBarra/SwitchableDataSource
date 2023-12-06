using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Implementation;

public class DataIOManagerAppendable<T> : DataIOManager<T>
{
    IDataAppender<T> Appender;

    public DataIOManagerAppendable(IDataSaver<T> _saver, IDataReader<T> _reader, IDataAppender<T> _appender)
        : base(_saver, _reader)
    {
        Appender = _appender;
    }


    public void SetAppendable(IDataAppender<T> _app)
    {
        if (_app == null) return;

        lock (SaverLock)
        {
            Appender = _app;
        }
    }


    public void Append(T e)
    {
        if (e == null) return;
        lock (SaverLock)
        {
            if (Saver != null)
                Appender.Append(e);
        }
    }

    public void Append(List<T> e)
    {
        if (e == null) return;

        lock (SaverLock)
        {
            if (Saver != null)
                Appender.Append(e);
        }
    }
}