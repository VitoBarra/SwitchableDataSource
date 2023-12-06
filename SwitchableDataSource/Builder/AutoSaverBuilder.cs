using SwitchableDataSource.Implementation;
using SwitchableDataSource.Interface;


public class AutoSaverBuilder<T>
{
    private int Rate = 30;
    private int IdleTime = 30;
    private string Name = "";

    public AutoSaverBuilder<T> SetRate(int rate)
    {
        Rate = rate;
        return this;
    }

    public AutoSaverBuilder<T> SetIdleTime(int _ideleTime)
    {
        IdleTime = _ideleTime;
        return this;
    }

    public AutoSaverBuilder<T> SetRate(int _times, int _idleTime)
    {
        Rate = _times;
        IdleTime = _idleTime;
        return this;
    }

    public AutoSaverBuilder<T> SetName(String optionalName)
    {
        Name = optionalName;
        return this;
    }

    public AutoSaverList<T> CreateAutoSaver(IMemoryListStrategy<T> mem)
    {
        return new AutoSaverList<T>(Rate, IdleTime, Name, mem);
    }

    public AutoSaverObject<T> CreateAutoSaver(IMemoryObjectStrategy<T> mem)
    {
        return new AutoSaverObject<T>(Rate, IdleTime, Name, mem);
    }
}