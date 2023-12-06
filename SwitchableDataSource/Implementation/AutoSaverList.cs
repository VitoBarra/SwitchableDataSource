using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Implementation;

public class AutoSaverList<T> : AbstractAutoSaver<T>, IMemoryListStrategy<T>
{
    private IMemoryListStrategy<T> Memorization;


    public AutoSaverList(int rate, int indleTime,string OptionalName, IMemoryListStrategy<T> _memorization)
        : base(rate, indleTime, OptionalName)
    {
        Memorization = _memorization;
    }

    public IList<T> ReadList()
    {
        return Memorization.ReadList();
    }

    public override IMemoryStrategy<T> GetMemorization()
    {
        return Memorization;
    }
}