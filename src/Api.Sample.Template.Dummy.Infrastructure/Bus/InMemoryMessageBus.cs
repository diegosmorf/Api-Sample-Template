using Api.Cqrs.Core.Bus;
using Api.Cqrs.Core.Commands;
using Api.Cqrs.Core.Events;
using MediatR;
using System.Threading.Tasks;

namespace Api.Sample.Template.Dummy.Infrastructure.Bus
{
    public class InMemoryMessageBus : IMessageBus
    {
        private readonly IMediator mediator;        

        public InMemoryMessageBus(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public Task DispatchCommand<TCommand>(TCommand command) where TCommand : ICommand
        {
           return mediator.Send(command);
        }

        public Task PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            return mediator.Publish(@event);
        }
    }
}