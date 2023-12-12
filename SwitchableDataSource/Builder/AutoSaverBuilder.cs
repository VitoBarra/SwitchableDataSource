using SwitchableDataSource.MemoryInteraction.Decorator.AutoSaver;
using SwitchableDataSource.Interface;


public class AutoSaverBuilder
{
    private int Rate = 30;
    private int IdleTime = 30;

    public AutoSaverBuilder SetRate(int rate)
    {
        Rate = rate;
        return this;
    }

    public AutoSaverBuilder SetIdleTime(int _ideleTime)
    {
        IdleTime = _ideleTime;
        return this;
    }

    public AutoSaverBuilder SetRate(int _times, int _idleTime)
    {
        Rate = _times;
        IdleTime = _idleTime;
        return this;
    }


    public IMemoryInteraction<T> CreateAutoSaver<T>(IMemoryInteraction<T> mem)
    {
        return new AutoSaver<T>(Rate, IdleTime, mem);
    }

}