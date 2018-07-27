using Api.Cqrs.Core.Bus;

namespace Api.Cqrs.Core.Events
{
    public interface IEvent : IMessage
    {        
        int Version { get; }
    }
}