using SwitchableDataSource.DataManagers;

namespace SwitchableDataSource.MemoryInteraction;

public class BufferedMemoryInteraction<T> : AbstractMemoryInteraction<T>
{
    private IList<T> Saved;
    private IList<T> UnSavedBuffer;
    protected override bool WriteAllowed => !DirtBit || UnSavedBuffer.Count == 0;

    public BufferedMemoryInteraction(MixingDataManager<T> dataManager, bool lazyInitialization = true, Type listType = null) :
        base(dataManager, listType)
    {
        DataManager = dataManager;
        if (!lazyInitialization) Initialize();
    }

    public override void AddOrModify(T? e)
    {
        if (e == null) return;
        Initialize();

        var existingInSaved = Saved.FirstOrDefault(x => x != null && x.Equals(e));
        if (existingInSaved != null)
        {
            UnSavedBuffer.Add(e);
            Saved.Remove(e);
        }
        else
        {
            var existingInUnsaved = UnSavedBuffer.FirstOrDefault(x => x != null && x.Equals(e));
            if (existingInUnsaved == null)
                UnSavedBuffer.Add(e);
        }
    }

    public override void Save()
    {
        Initialize();
        if (!WriteAllowed) return;

        DataManager.Save(UnSavedBuffer);
        Saved.ToList().AddRange(UnSavedBuffer);
        UnSavedBuffer.Clear();
    }

    public override void Append()
    {
        Initialize();
        if (!WriteAllowed) return;

        DataManager.Append(UnSavedBuffer.ToList());
        Saved.ToList().AddRange(UnSavedBuffer);
        UnSavedBuffer.Clear();
    }


    public override T? ReadObject()
    {
        return Saved[0];
    }

    public override IList<T?> ReadList()
    {
        Initialize();
        return Saved.Concat(UnSavedBuffer).ToList();
    }

    public override void SaveAndClose()
    {
        Save();
    }

    protected override void InitializationMethod()
    {
        base.InitializationMethod();
        UnSavedBuffer = (IList<T?>)Activator.CreateInstance(ListType);
    }
}