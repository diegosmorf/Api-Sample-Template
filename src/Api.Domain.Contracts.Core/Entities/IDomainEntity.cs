using System;
using System.Collections.Generic;

namespace Api.Domain.Contracts.Core.Entities
{
    public interface IDomainEntity
    {
        Guid Id { get; }
        DateTime CreatedDate { get; }
        DateTime ModifiedDate { get; }
        string ModifiedBy { get; }
        int Version { get; }
        IEnumerable<object> AppliedEvents { get; }
    }
}