using Api.Domain.Contracts.Core.Entities;
using Api.Sample.Template.Domain.Commands;
using Api.Sample.Template.Domain.Events;
using System;
using System.Collections.Generic;

namespace Api.Sample.Template.Domain.Model
{
    public class Fund : DomainEntity
    {
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public IEnumerable<Account> Accounts { get; protected set; }
        public void Create(CreateFundCommand command)
        {
            Version++;
            Id = Guid.NewGuid();
            Name = command.Name;
            Description = command.Description;
            CreatedDate = DateTime.Now;
            ModifiedBy = command.SenderUserName;

            appliedEvents.Add(new FundCreatedEvent(Id, Name, Description, CreatedDate, ModifiedDate, ModifiedBy));
        }
        
        public void Update(UpdateFundCommand command)
        {
            Version++;
            Name = command.Name;
            Description = command.Description;
            ModifiedDate = DateTime.Now;
            ModifiedBy = command.SenderUserName;

            appliedEvents.Add(new FundUpdatedEvent(Id, Name, Description, CreatedDate, ModifiedDate, ModifiedBy));
        }

        public void Delete(DeleteFundCommand command)
        {
            ModifiedBy = command.SenderUserName;
            appliedEvents.Add(new FundDeletedEvent(Id, ModifiedBy));
        }

        //public void AddAccounts(AddAccountToFund command)
        //{            
        //    appliedEvents.Add(new AccountAddedToFund((FundId,Id, Name, Description, CreatedDate, ModifiedDate, ModifiedBy));
        //}
    }
}