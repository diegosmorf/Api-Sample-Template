using Api.Domain.Contracts.Core.Entities;
using System.Collections.Generic;

namespace Api.Sample.Template.Domain.Model
{
    public class Account : DomainEntity
    {
        public string Name { get; set; }
        public string AccountNumber { get; set; }
        public string Description { get; set; }
        public IEnumerable<Transaction> Transactions { get; protected set; }
    }
}