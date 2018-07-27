using Api.Cqrs.Core.Bus;
using MediatR;

namespace Api.Cqrs.Core.Events
{
    public interface IEvent : IMessage, INotification
    {        
        int Version { get; }
    }
}