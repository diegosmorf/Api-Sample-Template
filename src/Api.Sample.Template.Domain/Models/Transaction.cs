using Api.Domain.Contracts.Core.Entities;

namespace Api.Sample.Template.Domain.Model
{
    public class Transaction : DomainEntity
    {
        public string JournalEntry { get; protected set; }
        public string AccountNumber { get; protected set; }
        public int Year{ get; set; }
        public decimal CreditAmmount { get; protected set; }
        public decimal DebitAmmount { get; protected set; }
        public decimal NetChange { get; protected set; }
    }
}