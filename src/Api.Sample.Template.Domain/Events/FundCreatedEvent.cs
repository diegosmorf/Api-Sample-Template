using Api.Cqrs.Core.Events;
using System;

namespace Api.Sample.Template.Domain.Events
{
    public class FundCreatedEvent: Event
    {
        public string Name { get; private set; }

        public string Description { get; private set; }       

        public FundCreatedEvent(Guid id, string name, string description, DateTime createdDate, DateTime modifiedDate, string modifiedBy)
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
