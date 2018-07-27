using System;
using System.Collections.Generic;

namespace Api.Domain.Contracts.Core.Entities
{
    public abstract class DomainEntity : IDomainEntity
    {
        public Guid Id { get; protected set; }
        public DateTime CreatedDate { get; protected set; }
        public DateTime ModifiedDate { get; protected set; }
        public string ModifiedBy { get; protected set; }        
        public override string ToString()
        {
            return $"Type:{GetType().Name} - Id:{Id}";
        }
        protected readonly List<object> appliedEvents = new List<object>();
        public int Version { get; protected set; }
        protected void OnApplied(object @event)
        {
            appliedEvents.Add(@event);
            Version++;
        }

        public IEnumerable<object> AppliedEvents => appliedEvents;
    }
}