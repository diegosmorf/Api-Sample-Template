using Api.Cqrs.Core.Events;
using System;

namespace Api.Sample.Template.Domain.Events
{
    public class FundDeletedEvent : Event
    {
        public FundDeletedEvent(Guid id, string modifiedBy)
        {
            Id = id;            
            ModifiedBy = modifiedBy;
        }
    }
}
