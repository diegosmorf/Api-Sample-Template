using System.Threading.Tasks;

namespace Api.Cqrs.Core.Events
{
    public interface IEventHandler<in TEvent> where TEvent : IEvent
    {
        Task Handle(TEvent @event);
    }
}