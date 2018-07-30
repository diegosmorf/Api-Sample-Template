using Api.Cqrs.Core.Bus;
using Api.Cqrs.Core.Commands;
using Api.Cqrs.Core.Events;
using Autofac;
using System.Collections.Generic;
using System.Threading.Tasks;
using Api.Cqrs.Core.CommandHandlers;
using Api.Domain.Contracts.Core.Entities;

namespace Api.Sample.Template.Mock.Infrastructure.Bus
{
    public class InMemoryMessageBus : IMessageBus
    {
        private readonly IComponentContext context;

        public InMemoryMessageBus(IComponentContext context)
        {
            this.context = context;
        }
        
        public Task<TEntity> DispatchCommand<TCommand, TEntity>(TCommand command) where TCommand : ICommand where TEntity: IDomainEntity
        {
            return context.Resolve<ICommandHandler<TCommand,TEntity>>().Handle(command);            
        }

        public Task PublishEvent<TEvent>(TEvent @event) where TEvent : IEvent
        {
            return context.Resolve<IEventHandler<TEvent>>().Handle(@event);
        }
    }
}