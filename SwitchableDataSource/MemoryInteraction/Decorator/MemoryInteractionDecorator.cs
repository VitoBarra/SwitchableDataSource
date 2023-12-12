using SwitchableDataSource.Interface;

namespace SwitchableDataSource.MemoryInteraction.Decorator;

public class MemoryInteractionDecorator<T> : IMemoryInteraction<T>
{
    protected IMemoryInteraction<T?> MemoryInteraction;

    protected MemoryInteractionDecorator(IMemoryInteraction<T?> memoryInteraction)
    {
        MemoryInteraction = memoryInteraction;
    }

    public virtual void AddOrModify(T? e)
    {
        MemoryInteraction.AddOrModify(e);
    }

    public virtual void Save()
    {
        MemoryInteraction.Save();
    }

    public void Append()
    {
        MemoryInteraction.Append();
    }

    public virtual void SaveAndClose()
    {
        MemoryInteraction.SaveAndClose();

    }

    public virtual T? ReadObject()
    {
        return MemoryInteraction.ReadObject();
    }

    public virtual IList<T?> ReadList()
    {
        return MemoryInteraction.ReadList();
    }

}