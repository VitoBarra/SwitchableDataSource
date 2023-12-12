using SwitchableDataSource.Interface;

namespace SwitchableDataSource.MemoryInteraction.Decorator.AutoSaver;

public abstract class AbstractAutoSaver<T> : MemoryInteractionDecorator<T>
{
    private readonly Timer AutoSaver;
    private int IdleTimeMil;
    private int RateMil;


    public AbstractAutoSaver(IMemoryInteraction<T?> memoryInteraction, int idleTimeMil =10000, int rateMil =10000) : base(
        memoryInteraction)
    {
        IdleTimeMil = idleTimeMil;
        RateMil = rateMil;
        AutoSaver = new Timer(o => AutoSave(), null, Timeout.Infinite, Timeout.Infinite);
    }

    private void AutoSave()
    {
        Save();
    }

    public override void SaveAndClose()
    {
        MemoryInteraction.SaveAndClose();
        AutoSaver.Dispose();
    }

    public void Pause()
    {
        AutoSaver.Change(Timeout.Infinite, Timeout.Infinite);
    }

    public void Start(int idleTimeMil=-1, int rateMil=-1)
    {
        if (idleTimeMil == -1) idleTimeMil = IdleTimeMil;
        if (rateMil == -1) rateMil = RateMil;

        AutoSaver.Change(idleTimeMil, rateMil);

        IdleTimeMil = idleTimeMil;
        RateMil = rateMil;

    }
}