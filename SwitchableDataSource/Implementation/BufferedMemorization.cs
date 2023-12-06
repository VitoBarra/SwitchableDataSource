using System.Collections.Generic;
using System.Linq;
using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Implementation;

public class BufferedMemorization<T> : AbstractMemorization<T>, IMemoryListStrategy<T>
{
    private IList<T> Saved;
    private IList<T> Unsaved;
    private DataIOManagerAppendable<T> Strategy;

    public BufferedMemorization(DataIOManagerAppendable<T> _strategy, bool LazyInitialization = true)
    {
        Strategy = _strategy;
        if (!LazyInitialization) Initialize();
    }

    public override void AddOrModify(T e)
    {
        lock (this)
        {
            Initialize();
            var existingInSaved = Saved.FirstOrDefault(x => x != null && x.Equals(e));
            if (existingInSaved != null)
            {
                Unsaved.Add(e);
                Saved.Remove(e);
            }
            else
            {
                var existingInUnsaved = Unsaved.FirstOrDefault(x => x != null && x.Equals(e));
                if (existingInUnsaved == null)
                    Unsaved.Add(e);
            }
        }
    }

    public override void Save()
    {
        lock (this)
        {
            if (!IsInitialized || !DirtBit || Unsaved.Count == 0) return;
            Strategy.Append(Unsaved.ToList());
            Saved.ToList().AddRange(Unsaved);
            Unsaved.Clear();
        }
    }

    //TODO: Implement Multiple Reader access
    public IList<T> ReadList()
    {
        Initialize();
        lock (this)
        {
            return Saved.Concat(Unsaved).ToList();
        }
    }

    public override void SaveAndClose()
    {
        Save();
    }

    protected override void InitializeStrategy()
    {
        Saved = ReadList();
        Unsaved = new List<T>();
    }
}