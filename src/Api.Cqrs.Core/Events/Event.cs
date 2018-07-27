using Api.Cqrs.Core.Bus;
using MediatR;
using System;

namespace Api.Cqrs.Core.Events
{
    public abstract class Event : Message, IEvent, INotification
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime ModifiedDate { get; protected set; }
        public string ModifiedBy { get; protected set; }
        public int Version { get; protected set; }
    }
}