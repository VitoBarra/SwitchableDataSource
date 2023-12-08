using SwitchableDataSource.Interface;

namespace SwitchableDataSource.DataInteraction.Decorator.AutoSaver;

public class AutoSaver<T> : AbstractAutoSaver<T>
{
    public AutoSaver(int idleTimeMil, int rateMil, IMemoryInteraction<T?> memoryInteraction) : base(memoryInteraction, idleTimeMil, rateMil)
    {
    }

}