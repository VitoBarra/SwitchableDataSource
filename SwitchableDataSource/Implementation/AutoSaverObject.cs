using SwitchableDataSource.Interface;

namespace SwitchableDataSource.Implementation;

public class AutoSaverObject<T> : AbstractAutoSaver<T>, IMemoryObjectStrategy<T>
{
    private IMemoryObjectStrategy<T> Memorization;


    public AutoSaverObject(int rate,int idleTime, string OptionalName, IMemoryObjectStrategy<T> _memorization)
        : base(rate, idleTime, OptionalName)
    {
        Memorization = _memorization;
    }


    public override IMemoryStrategy<T> GetMemorization()
    {
        return Memorization;
    }

    public  T ReadObject()
    {
        return Memorization.ReadObject();
    }
}