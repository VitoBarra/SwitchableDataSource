using SwitchableDataSource.Interface;
using SwitchableDataSource.MemoryInteraction.Decorator;

namespace SwitchableDataSource.DataInteraction.Decorator.Behaviour;

public class AbstractBehaviourDecorator<T> : DataInteractionDecorator<T>
{
    protected AbstractBehaviourDecorator(IDataInteraction<T> dataInteraction) : base(dataInteraction)
    {
    }
}