namespace SwitchableDataSource.Interface;

public abstract class AbstractAutoSaver<T> : IMemoryStrategy<T>
{
    private readonly Timer AutoSaver;
    private readonly string Name;



    public AbstractAutoSaver(int idleTimeMil,int rateMil,  string OptionalName)
    {
        Name = OptionalName;
        AutoSaver = new Timer(o=>AutoSave(),null,idleTimeMil,rateMil);
    }

    public void AutoSave()
    {
        Save();
    }

    public void AddOrModify(T e)
    {
        GetMemorization().AddOrModify(e);
    }

    public void Save()
    {
        GetMemorization().Save();
    }

    public void SaveAndClose()
    {
        GetMemorization().SaveAndClose();
        AutoSaver.Dispose();
    }

    public abstract IMemoryStrategy<T> GetMemorization();
}