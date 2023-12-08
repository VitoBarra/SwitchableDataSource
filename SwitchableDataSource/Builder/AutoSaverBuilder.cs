using SwitchableDataSource.DataInteraction.Decorator.AutoSaver;
using SwitchableDataSource.Interface;


public class AutoSaverBuilder<T>
{
    private int Rate = 30;
    private int IdleTime = 30;

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


    public AutoSaver<T> CreateAutoSaver(IMemoryInteraction<T> mem)
    {
        return new AutoSaver<T>(Rate, IdleTime, mem);
    }

}