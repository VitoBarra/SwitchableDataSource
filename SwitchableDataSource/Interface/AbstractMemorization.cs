
namespace SwitchableDataSource.Interface;

public abstract class AbstractMemorization<T> : IMemoryStrategy<T> {
    protected bool IsInitialized = false;
    protected bool DirtBit = false;


    protected void Initialize() {
        if (IsInitialized) return;
        InitializeStrategy();
        IsInitialized = true;
    }

    protected abstract void InitializeStrategy();
    public abstract void AddOrModify(T e);
    public abstract void Save();
    public abstract void SaveAndClose();
}
