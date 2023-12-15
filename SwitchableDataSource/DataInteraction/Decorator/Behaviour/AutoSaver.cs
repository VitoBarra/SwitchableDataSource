using SwitchableDataSource.DataInteraction.Decorator.Behaviour;
using SwitchableDataSource.Interface;

namespace SwitchableDataSource.MemoryInteraction.Decorator.AutoSaver;

public  class AutoSaver<T> : AbstractBehaviourDecorator<T>
{
    private readonly Timer AutoSaverTimer;
    private int IdleTimeMil;
    private int RateMil;


    public AutoSaver(IDataInteraction<T> dataInteraction, int idleTimeMil =10000, int rateMil =10000) : base(dataInteraction)
    {
        IdleTimeMil = idleTimeMil;
        RateMil = rateMil;
        AutoSaverTimer = new Timer(o => AutoSave(), null, Timeout.Infinite, Timeout.Infinite);
    }

    private void AutoSave()
    {
        SaveToSource();
    }

    public override void SaveAndClose()
    {
        DataInteraction.SaveAndClose();
        AutoSaverTimer.Dispose();
    }

    public void Pause()
    {
        AutoSaverTimer.Change(Timeout.Infinite, Timeout.Infinite);
    }

    public void Start(int idleTimeMil=-1, int rateMil=-1)
    {
        if (idleTimeMil == -1) idleTimeMil = IdleTimeMil;
        if (rateMil == -1) rateMil = RateMil;

        AutoSaverTimer.Change(idleTimeMil, rateMil);

        IdleTimeMil = idleTimeMil;
        RateMil = rateMil;

    }
}