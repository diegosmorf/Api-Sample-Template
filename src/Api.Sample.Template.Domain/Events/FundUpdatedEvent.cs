using Api.Cqrs.Core.Events;
using System;

namespace Api.Sample.Template.Domain.Events
{
    public class FundUpdatedEvent : Event
    {
        public string Name { get; private set; }

        public string Description { get; private set; }

        public FundUpdatedEvent(Guid id, string name, string description, DateTime createdDate, DateTime modifiedDate, string modifiedBy)
        {
            Id = id;
            Name = name;
            Description = description;
            CreatedDate = createdDate;
            ModifiedDate = modifiedDate;
            ModifiedBy = modifiedBy;
        }
    }    
}
