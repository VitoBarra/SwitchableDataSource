using SwitchableDataSource.Interface;
using SwitchableDataSource.MemoryInteraction.Decorator;

namespace SwitchableDataSource.DataInteraction.Decorator.Memory;

public abstract class  AbstractDataDecorator<T> : DataInteractionDecorator<T>
{
    protected AbstractDataDecorator(IDataInteraction<T> dataInteraction) : base(dataInteraction)
    {
    }
}