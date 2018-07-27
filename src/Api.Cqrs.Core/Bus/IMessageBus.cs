using Api.Cqrs.Core.Commands;
using Api.Cqrs.Core.Events;

namespace Api.Cqrs.Core.Bus
{
    public interface IMessageBus : ICommandDispatcher, IEventPublisher
    {
    }
}