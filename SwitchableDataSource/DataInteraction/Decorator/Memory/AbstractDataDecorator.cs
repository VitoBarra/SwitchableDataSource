using SwitchableDataSource.Interface;
using SwitchableDataSource.MemoryInteraction.Decorator;

namespace SwitchableDataSource.DataInteraction.Decorator.Memory;

public abstract class  AbstractDataDecorator<T> : DataInteractionDecorator<T>
{
    protected virtual bool WriteAllowed => DataInteraction.Count != 0;




    protected AbstractDataDecorator(IDataInteraction<T> dataInteraction) : base(dataInteraction)
    {
    }
}