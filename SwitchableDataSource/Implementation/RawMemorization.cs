using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Implementation;

public class RawMemorization<T> : AbstractMemorization<T>, IMemoryListStrategy<T>
{
    IList<T> Data;
    DataIOManager<T> Strategy;


    public RawMemorization(DataIOManager<T> _strategy) : this(_strategy, true)
    {
    }

    public RawMemorization(DataIOManager<T> _strategy, bool LazyRead)
    {
        Strategy = _strategy;
        if (!LazyRead) Initialize();
    }

    public override void AddOrModify(T e)
    {
        lock (this)
        {
            Initialize();
            Data.ToList().RemoveAll(x => x != null && x.Equals(e));
            Data.Add(e);
            DirtBit = true;
            DirtBit = true;
        }
    }


    public override void Save()
    {
        lock (this)
        {
            if (!IsInitialized || !DirtBit || Data.Count == 0) return;
            Strategy.Save(Data);
            DirtBit = false;
        }
    }


    public IList<T> ReadList()
    {
        Initialize();
        return Data;
    }



    protected override void InitializeStrategy()
    {
        Data = Strategy.ReadList() ?? new List<T>();
    }


    public override void SaveAndClose()
    {
        Save();
    }
}