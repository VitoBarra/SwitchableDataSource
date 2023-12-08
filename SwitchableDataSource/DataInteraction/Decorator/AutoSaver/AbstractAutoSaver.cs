using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataInteraction.Decorator.AutoSaver;

public abstract class AbstractAutoSaver<T> : MemoryInteractionDecorator<T>
{
    private readonly Timer AutoSaver;


    public AbstractAutoSaver(IMemoryInteraction<T?> memoryInteraction, int idleTimeMil, int rateMil):base(memoryInteraction)
    {

        AutoSaver = new Timer(o => AutoSave(), null, idleTimeMil, rateMil);
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

}