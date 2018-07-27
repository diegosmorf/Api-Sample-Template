using Api.Cqrs.Core.Bus;
using System;

namespace Api.Cqrs.Core.Events
{
    public abstract class Event : Message, IEvent
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime ModifiedDate { get; protected set; }
        public string ModifiedBy { get; protected set; }
        public int Version { get; protected set; }
    }
}