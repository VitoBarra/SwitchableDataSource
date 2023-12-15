using SwitchableDataSource.Interface;
using SwitchableDataSource.MemoryInteraction.Decorator;

namespace SwitchableDataSource.DataInteraction.Decorator.Memory;

public class BufferedInteraction<T> : DataInteractionDecorator<T>
{
    private readonly IList<T> UnSavedBuffer;
    private readonly int BufferSize;

    private bool IsBufferFull => UnSavedBuffer.Count >= BufferSize;

    protected override bool WriteAllowed => base.WriteAllowed && UnSavedBuffer.Count == 0;


    public BufferedInteraction(IDataInteraction<T> dataInteraction, int _bufferSize = 10) : base(dataInteraction)
    {
        UnSavedBuffer = DataInteraction.CreateListInstance();
        BufferSize = _bufferSize;
    }

    public override void AddOrModify(T element)
    {
        if (element == null) return;
        DataInteraction.DeleteIfExists(x => x != null && x.Equals(element));
        var existingInUnsaved = UnSavedBuffer.FirstOrDefault(x => x != null && x.Equals(element));

        if (existingInUnsaved != null)
            UnSavedBuffer.Remove(existingInUnsaved);

        UnSavedBuffer.Add(element);
    }

    public override void SaveToSource()
    {
        if (!WriteAllowed) return;

        DataInteraction.AddOrModify(UnSavedBuffer);
        DataInteraction.SaveToSource();
        UnSavedBuffer.Clear();
    }

    public override T? GetObjectWhere(Func<T, bool> getFunction)
    {
        var founded = UnSavedBuffer.FirstOrDefault(getFunction) ?? DataInteraction.GetObjectWhere(getFunction);
        return founded;
    }

    public override IList<T> ReadFromSource()
    {
        return DataInteraction.ReadFromSource().Concat(UnSavedBuffer).ToList();
    }

    public override void SaveAndClose()
    {
        SaveToSource();
    }
}